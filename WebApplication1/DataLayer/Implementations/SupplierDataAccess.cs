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
    public class SupplierDataAccess : ISupplierDataAccess
    {
        private SupplierContext Context { get; }
        private IMapper Mapper { get; }

        public SupplierDataAccess(SupplierContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Supplier> InsertAsync(SupplierUpdateModel supplier)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataLayer.Entities.Supplier>(supplier));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Supplier>(result.Entity);
        }

        public async Task<IEnumerable<Supplier>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Supplier>>(
                await this.Context.Supplier.ToListAsync());

        }

        public async Task<Supplier> GetAsync(ISupplierIdentity supplier)
        {
            var result = await this.Get(supplier);

            return this.Mapper.Map<Supplier>(result);
        }

        public async Task<Supplier> UpdateAsync(SupplierUpdateModel supplier)
        {
            var existing = await this.Get(supplier);

            var result = this.Mapper.Map(supplier, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Supplier>(result);
        }

        public async Task<Supplier> GetByAsync(ISupplierContainer supplier)
        {
            return supplier.SupplierId.HasValue 
                ? this.Mapper.Map<Supplier>(await this.Context.Supplier.FirstOrDefaultAsync(x => x.Id == supplier.SupplierId)) 
                : null;
        }

        private async Task<DataLayer.Entities.Supplier> Get(ISupplierIdentity supplier)
        {
            if(supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            return await this.Context.Supplier.FirstOrDefaultAsync(x => x.Id == supplier.Id);
        }
    }
}