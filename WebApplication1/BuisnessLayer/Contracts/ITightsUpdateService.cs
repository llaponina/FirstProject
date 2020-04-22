using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Contracts
{
    public interface ITightsUpdateService
    {
        Task<Tights> UpdateAsync(TightsUpdateModel tights);
    }
}