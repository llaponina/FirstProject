using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Contracts
{
    public interface ISupplierCreateService
    {
        Task<Supplier> CreateAsync(SupplierUpdateModel supplier);
    }
}