using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataLayer.Contracts
{
    public interface IBuyerDataAccess
    {
        Task<Buyer> InsertAsync(BuyerUpdateModel buyer);
        Task<IEnumerable<Buyer>> GetAsync();
        Task<Buyer> GetAsync(IBuyerIdentity buyerId);
        Task<Buyer> UpdateAsync(BuyerUpdateModel buyer);
        Task<Buyer> GetByAsync(IBuyerContainer buyer);

    }
}