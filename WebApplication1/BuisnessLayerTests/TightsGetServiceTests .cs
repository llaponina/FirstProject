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
    public class TightsGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_TightsExists_DoesNothing()
        {
            // Arrange
            var tightsContainer = new Mock<ITightsContainer>();

            var tights = new Tights();
            var tightsDataAccess = new Mock<ITightsDataAccess>();
            tightsDataAccess.Setup(x => x.GetByAsync(tightsContainer.Object)).ReturnsAsync(tights);

            var tightsGetService = new TightsGetService(tightsDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => tightsGetService.ValidateAsync(tightsContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_TightsNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var tightsContainer = new Mock<ITightsContainer>();
            tightsContainer.Setup(x => x.TightsId).Returns(id);

            var tights = new Tights();
            var tightsDataAccess = new Mock<ITightsDataAccess>();
            tightsDataAccess.Setup(x => x.GetByAsync(tightsContainer.Object)).ReturnsAsync((Tights)null);

            var tightsGetService = new TightsGetService(tightsDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => tightsGetService.ValidateAsync(tightsContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Tights not found by id {id}");
        }
    }
}