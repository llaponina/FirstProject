using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using DataLayer.Implementations;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Implementation
{
    public class BuyerCreateService : IBuyerCreateService
    {
        private IBuyerDataAccess BuyerDataAccess { get; }

        public BuyerCreateService(IBuyerDataAccess tightsDataAccess)
        {
            BuyerDataAccess = tightsDataAccess;
        }

        public Task<Buyer> CreateAsync(BuyerUpdateModel buyer)
        {
            return BuyerDataAccess.InsertAsync(buyer);
        }
    }
}