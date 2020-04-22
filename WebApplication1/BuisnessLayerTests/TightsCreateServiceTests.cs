using System;
using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using BuisnessLayer.Implementation;
using DataLayer.Contracts;
using Domain;
using Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using AutoFixture;


namespace BuisnessLayer.Tests
{
    public class TightsCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_DepartmentValidationSucceed_CreatesTights()
        {
            // Arrange
            var tights = new TightsUpdateModel();
            var expected = new Tights();
            
            var supplierGetService = new Mock<ISupplierGetService>();
            supplierGetService.Setup(x => x.ValidateAsync(tights));

            var buyerGetService = new Mock<IBuyerGetService>();
            buyerGetService.Setup(x => x.ValidateAsync(tights));

            var tightsDataAccess = new Mock<ITightsDataAccess>();
            tightsDataAccess.Setup(x => x.InsertAsync(tights)).ReturnsAsync(expected);
            
            var tightsGetService = new TightsCreateService(tightsDataAccess.Object, supplierGetService.Object, buyerGetService.Object);
            
            // Act
            var result = await tightsGetService.CreateAsync(tights);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_SupplierValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var tights = new TightsUpdateModel();
            var expected = fixture.Create<string>();
            
            var supplierGetService = new Mock<ISupplierGetService>();
            supplierGetService
                .Setup(x => x.ValidateAsync(tights))
                .Throws(new InvalidOperationException(expected));

            var buyerGetService = new Mock<IBuyerGetService>();
            buyerGetService.Setup(x => x.ValidateAsync(tights)).Throws(new InvalidOperationException(expected));

            
            var tightsDataAccess = new Mock<ITightsDataAccess>();

            var tightsGetService = new TightsCreateService(tightsDataAccess.Object, supplierGetService.Object, buyerGetService.Object);
            
            // Act
            var action = new Func<Task>(() => tightsGetService.CreateAsync(tights));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            tightsDataAccess.Verify(x => x.InsertAsync(tights), Times.Never);
        }
    }
}