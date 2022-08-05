using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warehouses.Services;

namespace Warehouses.Controllers.Api
{
    [Route("api/warehouse")]
    public class ApiWarehouseController : Controller
    {
        public IWarehouseService _warehouseService;
        private readonly ILogger<ApiWarehouseController> _logger;

        public ApiWarehouseController(IWarehouseService warehouseService, ILogger<ApiWarehouseController> logger)
        {
            _warehouseService = warehouseService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation($"Method {nameof(GetAll)} ");

            var warehouses = await _warehouseService.GetAllAsync();

            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Method {nameof(GetById)} with id {id}");

            var warehouse = await _warehouseService.GetByIdAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }
    }
}

