using System;
using System.Threading.Tasks;
using AutoFixture;
using BuisnessLayer.Implementation;
using DataLayer.Contracts;
using Domain;
using Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;


namespace BuisnessLayer.Tests
{
    public class BuyerGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_BuyerExists_DoesNothing()
        {
            // Arrange
            var departmentContainer = new Mock<IBuyerContainer>();

            var buyer = new Buyer();
            var buyerDataAccess = new Mock<IBuyerDataAccess>();
            buyerDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(buyer);

            var buyerGetService = new BuyerGetService(buyerDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => buyerGetService.ValidateAsync(departmentContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_BuyerNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var buyerContainer = new Mock<IBuyerContainer>();
            buyerContainer.Setup(x => x.BuyerId).Returns(id);

            var buyer = new Buyer();
            var buyerDataAccess = new Mock<IBuyerDataAccess>();
            buyerDataAccess.Setup(x => x.GetByAsync(buyerContainer.Object)).ReturnsAsync((Buyer)null);

            var buyerGetService = new BuyerGetService(buyerDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => buyerGetService.ValidateAsync(buyerContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Buyer not found by id {id}");
        }
    }
}