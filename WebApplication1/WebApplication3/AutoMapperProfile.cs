using AutoMapper;
using Client.DTO.Read;
using Client.Requests.Create;
using Client.Requests.Update;
using Domain.Models;

namespace WebApplication3
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataLayer.Entities.Supplier, Domain.Supplier>();
            this.CreateMap<DataLayer.Entities.Buyer, Domain.Buyer>();
            this.CreateMap<DataLayer.Entities.Tights, Domain.Tights>();
            this.CreateMap<Domain.Supplier, SupplierDTO>();
            this.CreateMap<Domain.Buyer, BuyerDTO>();
            this.CreateMap<Domain.Tights, TightsDTO>();
            
            this.CreateMap<SupplierCreateDTO, SupplierUpdateModel>();
            this.CreateMap<SupplierUpdateDTO, SupplierUpdateModel>();
            this.CreateMap<SupplierUpdateModel, DataLayer.Entities.Supplier>();
            
            this.CreateMap<BuyerCreateDTO, BuyerUpdateModel>();
            this.CreateMap<BuyerUpdateDTO, BuyerUpdateModel>();
            this.CreateMap<BuyerUpdateModel, DataLayer.Entities.Buyer>();
            
            this.CreateMap<TightsCreateDTO, TightsUpdateModel>();
            this.CreateMap<TightsUpdateDTO, TightsUpdateModel>();
            this.CreateMap<TightsUpdateModel, DataLayer.Entities.Tights>();
        }
    }
}