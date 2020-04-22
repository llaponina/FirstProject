using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using Domain;
using Domain.Contracts;

namespace BuisnessLayer.Implementation
{
    
    public class SupplierGetService : ISupplierGetService
    {
        private ISupplierDataAccess SupplierDataAccess { get; }
        
        public SupplierGetService(ISupplierDataAccess supplierDataAccess)
        {
            this.SupplierDataAccess = supplierDataAccess;
        }
        public Task<IEnumerable<Supplier>> GetAsync()
        {
            return this.SupplierDataAccess.GetAsync();
        }

        public Task<Supplier> GetAsync(ISupplierIdentity supplier)
        {
            return this.SupplierDataAccess.GetAsync(supplier);
        }

        public async Task ValidateAsync(ISupplierContainer supplierContainer)
        {
            if (supplierContainer == null)
            {
                throw new ArgumentNullException(nameof(supplierContainer));
            }
            
            var supplier = await this.GetBy(supplierContainer);

            if (supplierContainer.SupplierId.HasValue && supplier == null)
            {
                throw new InvalidOperationException($"Supplier not found by id {supplierContainer.SupplierId}");
            }
        }
        private Task<Supplier> GetBy(ISupplierContainer supplierContainer)
        {
            return this.SupplierDataAccess.GetByAsync(supplierContainer);
        }
    }
}