using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Implementation
{
    public class SupplierUpdateService : ISupplierUpdateService
    {
        private ISupplierDataAccess SupplierDataAccess { get; }

        public SupplierUpdateService(ISupplierDataAccess supplierDataAccess)
        {
            SupplierDataAccess = supplierDataAccess;
        }

        public Task<Supplier> UpdateAsync(SupplierUpdateModel supplier)
        {
            return SupplierDataAccess.UpdateAsync(supplier);
        }
    }
}