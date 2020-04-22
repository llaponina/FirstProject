using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;
namespace DataLayer.Contracts
{
    public interface ITightsDataAccess
    {
        Task<Tights> InsertAsync(TightsUpdateModel tights);
        Task<IEnumerable<Tights>> GetAsync();
        Task<Tights> GetAsync(ITightsIdentity tightsId);
        Task<Tights> UpdateAsync(TightsUpdateModel tights);
        Task<Tights> GetByAsync(ITightsContainer tights);

    }
}