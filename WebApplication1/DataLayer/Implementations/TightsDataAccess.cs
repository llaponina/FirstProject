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
    public class TightsDataAccess : ITightsDataAccess
    {
        private SupplierContext Context { get; }
        private IMapper Mapper { get; }

        public TightsDataAccess(SupplierContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Tights> InsertAsync(TightsUpdateModel tights)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataLayer.Entities.Tights>(tights));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Tights>(result.Entity);
        }

        public async Task<IEnumerable<Tights>> GetAsync()
        {
            //TODO
            return this.Mapper.Map<IEnumerable<Tights>>(await this.Context.Tights.Include(x => x.Supplier).Include(x=>x.Buyer).ToListAsync());
        }

        public async Task<Tights> GetAsync(ITightsIdentity tightsId)
        {

            var result = await this.Get(tightsId);
            return this.Mapper.Map<Tights>(result);
        }
        
        private async Task<DataLayer.Entities.Tights> Get(ITightsIdentity tightsId)
        {
            //TODO
            if (tightsId == null)
                throw new ArgumentNullException(nameof(tightsId));
            return await this.Context.Tights.Include(x => x.Supplier).Include(x=>x.Buyer).FirstOrDefaultAsync(x => x.Id == tightsId.Id);
            
        }

        public async Task<Tights> UpdateAsync(TightsUpdateModel tights)
        {
            var existing = await this.Get(tights);

            var result = this.Mapper.Map(tights, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Tights>(result);
        }

        public async Task<Tights> GetByAsync(ITightsContainer tights)
        {
            return tights.TightsId.HasValue 
                ? this.Mapper.Map<Tights>(await this.Context.Tights.FirstOrDefaultAsync(x => x.Id == tights.TightsId)) 
                : null;
        }
    }
}