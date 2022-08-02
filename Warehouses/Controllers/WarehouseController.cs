using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouses.Services;

namespace Warehouses.Controllers
{
    public class WarehouseController : Controller
    {
        private IWarehouseService _warehouseService;
        private IProductService _productService;

        public WarehouseController(IWarehouseService warehouseService, IProductService productService)
        {
            _warehouseService = warehouseService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _warehouseService.GetByIdAsync((int)id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }
    }
}

