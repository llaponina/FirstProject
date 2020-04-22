using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;
namespace DataLayer.Contracts
{
    public interface ISupplierDataAccess
    {
        Task<Supplier> InsertAsync(SupplierUpdateModel supplier);
        Task<IEnumerable<Supplier>> GetAsync();
        Task<Supplier> GetAsync(ISupplierIdentity supplierId);
        Task<Supplier> UpdateAsync(SupplierUpdateModel supplier);
        Task<Supplier> GetByAsync(ISupplierContainer departmentId);

    }
}