using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Contracts
{
    public interface IBuyerUpdateService
    {
        Task<Buyer> UpdateAsync(BuyerUpdateModel buyer);
    }
}