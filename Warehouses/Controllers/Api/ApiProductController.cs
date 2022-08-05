using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warehouses.Entities;
using Warehouses.Models;
using Warehouses.Services;

namespace Warehouses.Controllers.Api
{
    [Route("api/product")]
    public class ApiProductController : Controller
    {
        public IProductService _productService;
        private IHistoryService _historyService;
        private readonly ILogger<ApiProductController> _logger;

        public ApiProductController(IProductService productService, ILogger<ApiProductController> logger, IHistoryService historyService)
        {
            _productService = productService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _historyService = historyService;
        }

        [HttpPut]
        public async Task<bool> Update([FromBody] Product product)
        {
            _logger.LogInformation($"Method {nameof(Update)} ");

            if (!HttpContext.Session.Keys.Contains("warehouseMan"))
            {
                return false;
            }

            var response = await _productService.UpdateAsync(product);

            if (response)
            {
                var history = new History
                {
                    Date = DateTime.Now,
                    Message = $"Кладовщик Id = {HttpContext.Session.GetInt32("warehouseMan")}, увеличил 1 {product.Name}, на складе Id = {product.WarehouseId}"
                };

                await _historyService.CreateAsync(history);
            }

            return response;
        }
    }
}

