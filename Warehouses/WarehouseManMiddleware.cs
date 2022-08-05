using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Warehouses.Services;
using System.Linq;

namespace Warehouses
{
    public class WarehouseManMiddleware
    {
        private readonly RequestDelegate _next;

        public WarehouseManMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IWarehouseManService warehouseManService)
        {
            if (!context.Session.Keys.Contains("warehouseMan"))
            {
                var freeMans = await warehouseManService.GetAllFreeAsync();
                var freeMan = freeMans.FirstOrDefault();

                if (freeMan != null)
                {
                    //context.Session.SetString("warehouseMan", freeMan.Name);
                    context.Session.SetInt32("warehouseMan", freeMan.Id);
                    await warehouseManService.UpdateBusyAsync((int)context.Session.GetInt32("warehouseMan"));
                }
            }
            else
            {
                await warehouseManService.UpdateBusyAsync((int)context.Session.GetInt32("warehouseMan"));
            }

            await _next.Invoke(context);
        }
    }
}

