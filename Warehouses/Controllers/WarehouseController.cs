using System;
using System.Linq;
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
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = _warehouseService.GetById((int)id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var product = _productService.GetById(id);

            if (product != null)
            {
                product.Count++;
            }

            return RedirectToAction("Index", new { id = product.WarehouseId });
        }

        [HttpGet]
        public IActionResult Subtract(int id)
        {
            var product = _productService.GetById(id);

            if (product != null && product.Count > 0)
            {
                product.Count--;
            }

            return RedirectToAction("Index", new { id = product.WarehouseId });
        }
    }
}

