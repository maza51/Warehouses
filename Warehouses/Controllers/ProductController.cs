using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warehouses.Entities;
using Warehouses.Services;

namespace Warehouses.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IHistoryService _historyService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, IHistoryService historyService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _historyService = historyService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("add/{id}")]
        public async Task<IActionResult> Add(int id)
        {
            _logger.LogInformation($"Method {nameof(Add)} ");

            if (!HttpContext.Session.Keys.Contains("warehouseMan"))
            {
                return Content("Вам не присвоен кладовщик или нет свободных кладовщиков");
            }

            var product = await _productService.GetByIdAsync(id);

            await Update(product, true);

            return RedirectToAction("Details", "Warehouse", new { id = product.WarehouseId });
        }

        [HttpGet("subtract/{id}")]
        public async Task<IActionResult> Subtract(int id)
        {
            _logger.LogInformation($"Method {nameof(Subtract)} ");

            if (!HttpContext.Session.Keys.Contains("warehouseMan"))
            {
                return Content("Вам не присвоен кладовщик или нет свободных кладовщиков");
            }

            var product = await _productService.GetByIdAsync(id);

            await Update(product, false);

            return RedirectToAction("Details", "Warehouse", new { id = product.WarehouseId });
        }

        private static SemaphoreSlim _simaphoreUpdate = new SemaphoreSlim(1);

        private async Task Update(Product product, bool add)
        {
            await _simaphoreUpdate.WaitAsync();

            if (product != null)
            {
                if (add)
                {
                    product.Count++;
                }
                else
                {
                    product.Count--;
                }
            }

            var response = await _productService.UpdateAsync(product);

            if (response)
            {
                var history = new History
                {
                    Date = DateTime.Now,
                    Message = $"Кладовщик Id = {HttpContext.Session.GetInt32("warehouseMan")}, {(add?"увеличил":"уменьшил")} 1 {product.Name}, на складе Id = {product.WarehouseId}"
                };

                _logger.LogInformation(history.Message);

                await _historyService.CreateAsync(history);
            }

            _simaphoreUpdate.Release();
        }
    }
}

