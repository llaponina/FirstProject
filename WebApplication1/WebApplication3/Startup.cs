using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLayer.Contracts;
using BuisnessLayer.Implementation;
using DataLayer;
using DataLayer.Contracts;
using DataLayer.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;


namespace WebApplication3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runsize. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BuisnessLayerL
            services.Add(new ServiceDescriptor(typeof(ISupplierCreateService),typeof(SupplierCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISupplierGetService),typeof(SupplierGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISupplierUpdateService),typeof(SupplierUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBuyerCreateService),typeof(BuyerCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBuyerGetService),typeof(BuyerGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IBuyerUpdateService),typeof(BuyerUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ITightsCreateService),typeof(TightsCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ITightsGetService),typeof(TightsGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ITightsUpdateService),typeof(TightsUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(ISupplierDataAccess), typeof(SupplierDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IBuyerDataAccess), typeof(BuyerDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ITightsDataAccess), typeof(TightsDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            services.AddDbContext<SupplierContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("Suppliers")));
        }

        // This method gets called by the runsize. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SupplierContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}