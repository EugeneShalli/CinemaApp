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
    public class LoyaltyCardServiceTest
    {
        [Test]
        public async Task ValidateAsync_LoyaltyCardExists_DoesNothing()
        {
            // Arrange
            var loyaltycardContainer = new Mock<ILoyaltyCardContainer>();

            var loyaltycard = new LoyaltyCard();
            var loyaltycardDAL = new Mock<ILoyaltyCardDAL>();
            var loyaltycardIdentity = new Mock<ILoyaltyCardIdentity>();
            loyaltycardDAL.Setup(x => x.GetAsync(loyaltycardIdentity.Object)).ReturnsAsync(loyaltycard);

            var loyaltycardGetService = new LoyaltyCardService(loyaltycardDAL.Object);
            
            // Act
            var action = new Func<Task>(() => loyaltycardGetService.ValidateAsync(loyaltycardContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_LoyaltyCardNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var loyaltycardContainer = new Mock<ILoyaltyCardContainer>();
            loyaltycardContainer.Setup(x => x.LoyaltyCardId).Returns(id);
            var loyaltycardIdentity = new Mock<ILoyaltyCardIdentity>();
            var loyaltycard = new LoyaltyCard();
            var loyaltycardDAL = new Mock<ILoyaltyCardDAL>();
            loyaltycardDAL.Setup(x => x.GetAsync(loyaltycardIdentity.Object)).ReturnsAsync((LoyaltyCard) null);

            var loyaltycardGetService = new LoyaltyCardService(loyaltycardDAL.Object);

            // Act
            var action = new Func<Task>(() => loyaltycardGetService.ValidateAsync(loyaltycardContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"LoyaltyCard not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_LoyaltyCardValidationSucceed_CreatesLoyaltyCard()
        {
            // Arrange
            var loyaltycard = new LoyaltyCardUpdateModel();
            var expected = new LoyaltyCard();
            
            var loyaltycardDAL = new Mock<ILoyaltyCardDAL>();
            loyaltycardDAL.Setup(x => x.InsertAsync(loyaltycard)).ReturnsAsync(expected);

            var loyaltycardService = new LoyaltyCardService(loyaltycardDAL.Object);
            
            // Act
            var result = await loyaltycardService.CreateAsync(loyaltycard);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}