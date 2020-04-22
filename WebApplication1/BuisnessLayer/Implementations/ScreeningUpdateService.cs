using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using DataLayer.Contracts;
using Domain;
using Domain.Models;

namespace BuisnessLayer.Implementation
{
    public class TightsUpdateService : ITightsUpdateService
    {
        private ITightsDataAccess TightsDataAccess { get; }
        private IBuyerGetService BuyerGetService { get; }
        private ISupplierGetService SupplierGetService { get; }

        public TightsUpdateService(ITightsDataAccess tightsDataAccess, ISupplierGetService supplierGetService,
            IBuyerGetService buyerGetService)
        {
            TightsDataAccess = tightsDataAccess;
            BuyerGetService = buyerGetService;
            SupplierGetService = supplierGetService;
        }

        public async Task<Tights> UpdateAsync(TightsUpdateModel tights)
        {
            await BuyerGetService.ValidateAsync(tights);
            await SupplierGetService.ValidateAsync(tights);

            return await TightsDataAccess.UpdateAsync(tights);

        }
    }
}