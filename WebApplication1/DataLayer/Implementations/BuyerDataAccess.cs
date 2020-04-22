using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Contracts;
using Domain;
using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DataLayer.Implementations
{
    public class BuyerDataAccess : IBuyerDataAccess
    {
        private SupplierContext Context { get; }
        private IMapper Mapper { get; }

        public BuyerDataAccess(SupplierContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Buyer> InsertAsync(BuyerUpdateModel buyer)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataLayer.Entities.Buyer>(buyer));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Buyer>(result.Entity);
        }

        public async Task<IEnumerable<Buyer>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Buyer>>(
                await this.Context.Buyer.ToListAsync());
        }

        public async Task<Buyer> GetAsync(IBuyerIdentity buyer)
        {
            var result = await this.Get(buyer);

            return this.Mapper.Map<Buyer>(result);
        }

        public async Task<Buyer> UpdateAsync(BuyerUpdateModel buyer)
        {
            var existing = await this.Get(buyer);

            var result = this.Mapper.Map(buyer, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Buyer>(result);
        }

        public async Task<Buyer> GetByAsync(IBuyerContainer buyer)
        {
            return buyer.BuyerId.HasValue 
                ? this.Mapper.Map<Buyer>(await this.Context.Buyer.FirstOrDefaultAsync(x => x.Id == buyer.BuyerId)) 
                : null;
        }

        private async Task<DataLayer.Entities.Buyer> Get(IBuyerIdentity buyer)
        {
            if(buyer == null)
                throw new ArgumentNullException(nameof(buyer));
            return await this.Context.Buyer.FirstOrDefaultAsync(x => x.Id == buyer.Id);
        }
    }
}