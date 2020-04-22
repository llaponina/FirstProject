using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Implementation
{
    public class BuyerUpdateService : IBuyerUpdateService
    {
        private IBuyerDataAccess BuyerDataAccess { get; }

        public BuyerUpdateService(IBuyerDataAccess tightsDataAccess)
        {
            BuyerDataAccess = tightsDataAccess;
        }

        public Task<Buyer> UpdateAsync(BuyerUpdateModel buyer)
        {
            return BuyerDataAccess.UpdateAsync(buyer);
        }
    }
}