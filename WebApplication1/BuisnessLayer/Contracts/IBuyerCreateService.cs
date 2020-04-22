using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Contracts
{
    public interface IBuyerCreateService
    {
        Task<Buyer> CreateAsync(BuyerUpdateModel buyer);
    }
}