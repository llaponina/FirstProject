using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuisnessLayer.Contracts;
using Client.DTO.Read;
using Client.Requests.Create;
using Client.Requests.Update;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/buyer")]
    public class BuyerController : ControllerBase
    {
        private ILogger<BuyerController> Logger { get; }
        private IBuyerCreateService BuyerCreateService { get; }
        private IBuyerGetService BuyerGetService { get; }
        private IBuyerUpdateService BuyerUpdateService { get; }
        private IMapper Mapper { get; }

        public BuyerController(ILogger<BuyerController> logger, IMapper mapper, IBuyerCreateService buyerCreateService, IBuyerGetService buyerGetService, IBuyerUpdateService buyerUpdateService)
        {
            this.Logger = logger;
            this.BuyerCreateService = buyerCreateService;
            this.BuyerGetService = buyerGetService;
            this.BuyerUpdateService = buyerUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<BuyerDTO> PutAsync(BuyerCreateDTO buyer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BuyerCreateService.CreateAsync(this.Mapper.Map<BuyerUpdateModel>(buyer));

            return this.Mapper.Map<BuyerDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<BuyerDTO> PatchAsync(BuyerUpdateDTO buyer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BuyerUpdateService.UpdateAsync(this.Mapper.Map<BuyerUpdateModel>(buyer));

            return this.Mapper.Map<BuyerDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BuyerDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<BuyerDTO>>(await this.BuyerGetService.GetAsync());
        }

        [HttpGet]
        [Route("{buyerId}")]
        public async Task<BuyerDTO> GetAsync(int buyerId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {buyerId}");

            return this.Mapper.Map<BuyerDTO>(await this.BuyerGetService.GetAsync(new BuyerIdentityModel(buyerId)));
        }
    }
}