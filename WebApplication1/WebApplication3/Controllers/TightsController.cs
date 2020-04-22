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
    [Route("api/tights")]
    public class TightsController
    {
        private ILogger<TightsController> Logger { get; }
        private ITightsCreateService TightsCreateService { get; }
        private ITightsGetService TightsGetService { get; }
        private ITightsUpdateService TightsUpdateService { get; }
        private IMapper Mapper { get; }

        public TightsController(ILogger<TightsController> logger, IMapper mapper, ITightsCreateService tightsCreateService, ITightsGetService tightsGetService, ITightsUpdateService tightsUpdateService)
        {
            this.Logger = logger;
            this.TightsCreateService = tightsCreateService;
            this.TightsGetService = tightsGetService;
            this.TightsUpdateService = tightsUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<TightsDTO> PutAsync(TightsCreateDTO tights)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.TightsCreateService.CreateAsync(this.Mapper.Map<TightsUpdateModel>(tights));

            return this.Mapper.Map<TightsDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<TightsDTO> PatchAsync(TightsUpdateDTO tights)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.TightsUpdateService.UpdateAsync(this.Mapper.Map<TightsUpdateModel>(tights));

            return this.Mapper.Map<TightsDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<TightsDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<TightsDTO>>(await this.TightsGetService.GetAsync());
        }

        [HttpGet]
        [Route("{tightsId}")]
        public async Task<TightsDTO> GetAsync(int tightsId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {tightsId}");

            return this.Mapper.Map<TightsDTO>(await this.TightsGetService.GetAsync(new TightsIdentityModel(tightsId)));
        }
    }
}