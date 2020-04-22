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
    public class SupplierGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_SupplierExists_DoesNothing()
        {
            // Arrange
            var supplierContainer = new Mock<ISupplierContainer>();

            var supplier = new Supplier();
            var supplierDataAccess = new Mock<ISupplierDataAccess>();
            supplierDataAccess.Setup(x => x.GetByAsync(supplierContainer.Object)).ReturnsAsync(supplier);

            var supplierGetService = new SupplierGetService(supplierDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => supplierGetService.ValidateAsync(supplierContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_SupplierNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var supplierContainer = new Mock<ISupplierContainer>();
            supplierContainer.Setup(x => x.SupplierId).Returns(id);

            var supplier = new Supplier();
            var supplierDataAccess = new Mock<ISupplierDataAccess>();
            supplierDataAccess.Setup(x => x.GetByAsync(supplierContainer.Object)).ReturnsAsync((Supplier)null);

            var supplierGetService = new SupplierGetService(supplierDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => supplierGetService.ValidateAsync(supplierContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Supplier not found by id {id}");
        }
    }
}