using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using Domain;
using Domain.Contracts;

namespace BuisnessLayer.Implementation
{
    public class TightsGetService : ITightsGetService
    {
        private ITightsDataAccess TightsDataAccess { get; }
        
        public TightsGetService(ITightsDataAccess supplierDataAccess)
        {
            this.TightsDataAccess = supplierDataAccess;
        }
        public Task<IEnumerable<Tights>> GetAsync()
        {
            return this.TightsDataAccess.GetAsync();
        }

        public Task<Tights> GetAsync(ITightsIdentity tights)
        {
            return this.TightsDataAccess.GetAsync(tights);
        }

        public async Task ValidateAsync(ITightsContainer tightsContainer)
        {
            if (tightsContainer == null)
            {
                throw new ArgumentNullException(nameof(tightsContainer));
            }
            
            var tights = await this.GetBy(tightsContainer);

            if (tightsContainer.TightsId.HasValue && tights == null)
            {
                throw new InvalidOperationException($"Tights not found by id {tightsContainer.TightsId}");
            }
        }
        private Task<Tights> GetBy(ITightsContainer departmentContainer)
        {
            return this.TightsDataAccess.GetByAsync(departmentContainer);
        }
    }
}