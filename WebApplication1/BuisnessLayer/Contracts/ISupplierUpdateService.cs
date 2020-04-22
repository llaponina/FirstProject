using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Contracts
{
    public interface ISupplierUpdateService
    {
        Task<Supplier> UpdateAsync(SupplierUpdateModel supplier);
    }
}