using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using CinemaApp.BLL.Contracts;
using CinemaApp.BLL.Implementation;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;
using NUnit.Framework;

namespace CinemaApp.BLL.Tests.Unit
{
    [TestFixture]
    public class VisitorServiceTest
    {
        [Test]
        public async Task ValidateAsync_VisitorExists_DoesNothing()
        {
            // Arrange
            var visitorContainer = new Mock<IVisitorContainer>();

            var visitor = new Visitor();
            var loyaltycardService = new Mock<ILoyaltyCardService>();
            var visitorDAL = new Mock<IVisitorDAL>();
            var visitorIdentity = new Mock<IVisitorIdentity>();
            visitorDAL.Setup(x => x.GetAsync(visitorIdentity.Object)).ReturnsAsync(visitor);

            var visitorGetService = new VisitorService(visitorDAL.Object,loyaltycardService.Object);
            
            // Act
            var action = new Func<Task>(() => visitorGetService.ValidateAsync(visitorContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_VisitorNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var visitorContainer = new Mock<IVisitorContainer>();
            visitorContainer.Setup(x => x.VisitorId).Returns(id);
            var visitorIdentity = new Mock<IVisitorIdentity>();
            var loyaltycardService = new Mock<ILoyaltyCardService>();
            var visitor = new Visitor();
            var visitorDAL = new Mock<IVisitorDAL>();
            visitorDAL.Setup(x => x.GetAsync(visitorIdentity.Object)).ReturnsAsync((Visitor) null);

            var visitorGetService = new VisitorService(visitorDAL.Object,loyaltycardService.Object);

            // Act
            var action = new Func<Task>(() => visitorGetService.ValidateAsync(visitorContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Visitor not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_VisitorValidationSucceed_CreatesVisitor()
        {
            // Arrange
            var visitor = new VisitorUpdateModel();
            var expected = new Visitor();
            
            var loyaltycardService = new Mock<ILoyaltyCardService>();
            loyaltycardService.Setup(x => x.ValidateAsync(visitor));

            var visitorDAL = new Mock<IVisitorDAL>();
            visitorDAL.Setup(x => x.InsertAsync(visitor)).ReturnsAsync(expected);

            var visitorService = new VisitorService(visitorDAL.Object, loyaltycardService.Object);
            
            // Act
            var result = await visitorService.CreateAsync(visitor);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_VisitorValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var visitor = new VisitorUpdateModel();
            var expected = fixture.Create<string>();
            
            var loyaltycardService = new Mock<ILoyaltyCardService>();
            loyaltycardService
                .Setup(x => x.ValidateAsync(visitor))
                .Throws(new InvalidOperationException(expected));
            
            var visitorDAL = new Mock<IVisitorDAL>();
            
            var visitorService = new VisitorService(visitorDAL.Object, loyaltycardService.Object);
            
            var action = new Func<Task>(() => visitorService.CreateAsync(visitor));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            visitorDAL.Verify(x => x.InsertAsync(visitor), Times.Never);
        }
    }
}