using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using CinemaApp.BLL.Implementation;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;
using NUnit.Framework;

namespace CinemaApp.BLL.Tests.Unit
{
    [TestFixture]
    public class FilmServiceTest
    {
        [Test]
        public async Task ValidateAsync_FilmExists_DoesNothing()
        {
            // Arrange
            var filmContainer = new Mock<IFilmContainer>();

            var film = new Film();
            var filmDAL = new Mock<IFilmDAL>();
            var filmIdentity = new Mock<IFilmIdentity>();
            filmDAL.Setup(x => x.GetAsync(filmIdentity.Object)).ReturnsAsync(film);

            var filmGetService = new FilmService(filmDAL.Object);
            
            // Act
            var action = new Func<Task>(() => filmGetService.ValidateAsync(filmContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_FilmNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var filmContainer = new Mock<IFilmContainer>();
            filmContainer.Setup(x => x.FilmId).Returns(id);
            var filmIdentity = new Mock<IFilmIdentity>();
            var film = new Film();
            var filmDAL = new Mock<IFilmDAL>();
            filmDAL.Setup(x => x.GetAsync(filmIdentity.Object)).ReturnsAsync((Film) null);

            var filmGetService = new FilmService(filmDAL.Object);

            // Act
            var action = new Func<Task>(() => filmGetService.ValidateAsync(filmContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Film not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_FilmValidationSucceed_CreatesLoyaltyCard()
        {
            // Arrange
            var film = new FilmUpdateModel();
            var expected = new Film();
            
            var filmDAL = new Mock<IFilmDAL>();
            filmDAL.Setup(x => x.InsertAsync(film)).ReturnsAsync(expected);

            var filmService = new FilmService(filmDAL.Object);
            
            // Act
            var result = await filmService.CreateAsync(film);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}