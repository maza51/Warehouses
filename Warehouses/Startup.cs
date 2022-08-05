using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Warehouses.Data;
using Warehouses.Services;

namespace Warehouses
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(_configuration.GetConnectionString("AppDbContext")));

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IWarehouseService, WarehouseService>();
            services.AddTransient<IWarehouseManService, WarehouseManService>();
            services.AddTransient<IHistoryService, HistoryService>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".Warehouses.session";
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromSeconds(600);
                
            });

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IWarehouseManService warehouseManService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseSession();

            app.UseMiddleware<WarehouseManMiddleware>();

            app.UseMvc();
            app.UseMvcWithDefaultRoute();
        }
    }
}

