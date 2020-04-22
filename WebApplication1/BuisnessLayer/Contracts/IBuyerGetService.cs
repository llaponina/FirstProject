using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BuisnessLayer.Contracts
{
    public interface IBuyerGetService
    {
        Task<IEnumerable<Buyer>> GetAsync();
        Task<Buyer> GetAsync(IBuyerIdentity buyer);
        Task ValidateAsync(IBuyerContainer departmentContainer);
    }
}