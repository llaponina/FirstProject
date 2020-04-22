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
    [Route("api/supplier")]
    public class SupplierController
    {
        private ILogger<SupplierController> Logger { get; }
        private ISupplierCreateService SupplierCreateService { get; }
        private ISupplierGetService SupplierGetService { get; }
        private ISupplierUpdateService SupplierUpdateService { get; }
        private IMapper Mapper { get; }

        public SupplierController(ILogger<SupplierController> logger, IMapper mapper, ISupplierCreateService supplierCreateService, ISupplierGetService supplierGetService, ISupplierUpdateService supplierUpdateService)
        {
            this.Logger = logger;
            this.SupplierCreateService = supplierCreateService;
            this.SupplierGetService = supplierGetService;
            this.SupplierUpdateService = supplierUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<SupplierDTO> PutAsync(SupplierCreateDTO supplier)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.SupplierCreateService.CreateAsync(this.Mapper.Map<SupplierUpdateModel>(supplier));

            return this.Mapper.Map<SupplierDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<SupplierDTO> PatchAsync(SupplierUpdateDTO supplier)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.SupplierUpdateService.UpdateAsync(this.Mapper.Map<SupplierUpdateModel>(supplier));

            return this.Mapper.Map<SupplierDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<SupplierDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<SupplierDTO>>(await this.SupplierGetService.GetAsync());
        }

        [HttpGet]
        [Route("{supplierId}")]
        public async Task<SupplierDTO> GetAsync(int supplierId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {supplierId}");

            return this.Mapper.Map<SupplierDTO>(await this.SupplierGetService.GetAsync(new SupplierIdentityModel(supplierId)));
        }
    }
}