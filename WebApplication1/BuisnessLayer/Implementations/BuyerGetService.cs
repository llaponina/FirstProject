using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using Domain;
using Domain.Contracts;

namespace BuisnessLayer.Implementation
{
    public class BuyerGetService : IBuyerGetService
    {
        private IBuyerDataAccess BuyerDataAccess { get; }
        
        public BuyerGetService(IBuyerDataAccess buyerDataAccess)
        {
            this.BuyerDataAccess = buyerDataAccess;
        }
        public Task<IEnumerable<Buyer>> GetAsync()
        {
            return this.BuyerDataAccess.GetAsync();
        }

        public Task<Buyer> GetAsync(IBuyerIdentity buyer)
        {
            return this.BuyerDataAccess.GetAsync(buyer);
        }

        public async Task ValidateAsync(IBuyerContainer buyerContainer)
        {
            if (buyerContainer == null)
            {
                throw new ArgumentNullException(nameof(buyerContainer));
            }
            
            var tights = await this.GetBy(buyerContainer);

            if (buyerContainer.BuyerId.HasValue && tights == null)
            {
                throw new InvalidOperationException($"Tights not found by id {buyerContainer.BuyerId}");
            }
        }
        private Task<Buyer> GetBy(IBuyerContainer departmentContainer)
        {
            return this.BuyerDataAccess.GetByAsync(departmentContainer);
        }
    }
}