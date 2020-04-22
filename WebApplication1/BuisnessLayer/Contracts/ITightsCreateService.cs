using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Contracts
{
    public interface ITightsCreateService
    {
        Task<Tights> CreateAsync(TightsUpdateModel tights);
    }
}