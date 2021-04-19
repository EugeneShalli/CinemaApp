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
    public class SessionServiceTest
    {
        [Test]
        public async Task ValidateAsync_SessionExists_DoesNothing()
        {
            // Arrange
            var sessionContainer = new Mock<ISessionContainer>();

            var session = new Session();
            var sessionDAL = new Mock<ISessionDAL>();
            var sessionIdentity = new Mock<ISessionIdentity>();
            sessionDAL.Setup(x => x.GetAsync(sessionIdentity.Object)).ReturnsAsync(session);

            var sessionGetService = new SessionService(sessionDAL.Object);
            
            // Act
            var action = new Func<Task>(() => sessionGetService.ValidateAsync(sessionContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_SessionNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var sessionContainer = new Mock<ISessionContainer>();
            sessionContainer.Setup(x => x.SessionId).Returns(id);
            var sessionIdentity = new Mock<ISessionIdentity>();
            var session = new Session();
            var sessionDAL = new Mock<ISessionDAL>();
            sessionDAL.Setup(x => x.GetAsync(sessionIdentity.Object)).ReturnsAsync((Session) null);

            var sessionGetService = new SessionService(sessionDAL.Object);

            // Act
            var action = new Func<Task>(() => sessionGetService.ValidateAsync(sessionContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Session not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_SessionValidationSucceed_CreatesLoyaltyCard()
        {
            // Arrange
            var session = new SessionUpdateModel();
            var expected = new Session();

            var sessionDAL = new Mock<ISessionDAL>();
            sessionDAL.Setup(x => x.InsertAsync(session)).ReturnsAsync(expected);

            var sessionService = new SessionService(sessionDAL.Object);
            
            // Act
            var result = await sessionService.CreateAsync(session);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}