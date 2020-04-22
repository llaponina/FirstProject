using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BuisnessLayer.Contracts
{
    public interface ISupplierGetService
    {
        Task<IEnumerable<Supplier>> GetAsync();
        Task<Supplier> GetAsync(ISupplierIdentity supplier);
        Task ValidateAsync(ISupplierContainer departmentContainer);
    }
}