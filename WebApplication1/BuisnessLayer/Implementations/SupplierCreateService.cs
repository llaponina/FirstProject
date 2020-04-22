using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Implementation
{
    public class SupplierCreateService : ISupplierCreateService
    {
        private ISupplierDataAccess SupplierDataAccess { get; }

        public SupplierCreateService(ISupplierDataAccess supplierDataAccess)
        {
            SupplierDataAccess = supplierDataAccess;
        }

        public  Task<Supplier> CreateAsync(SupplierUpdateModel supplier)
        {
            return SupplierDataAccess.InsertAsync(supplier);
        }
    }
}