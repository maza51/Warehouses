using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Warehouses.Services;

namespace Warehouses.Controllers
{
    [Route("warehouse")]
    public class WarehouseController : Controller
    {
        private IWarehouseService _warehouseService;
        private readonly ILogger<WarehouseController> _logger;

        public WarehouseController(IWarehouseService warehouseService, ILogger<WarehouseController> logger)
        {
            _warehouseService = warehouseService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation($"Method {nameof(Index)} ");

            var warehouses = await _warehouseService.GetAllAsync();

            return View(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            _logger.LogInformation($"Method {nameof(Details)} with id {id}");

            var warehouse = await _warehouseService.GetByIdAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }
    }
}

