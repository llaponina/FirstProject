using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BuisnessLayer.Contracts
{
    public interface ITightsGetService
    {
        Task<IEnumerable<Tights>> GetAsync();
        Task<Tights> GetAsync(ITightsIdentity tights);
        Task ValidateAsync(ITightsContainer departmentContainer);
    }
}