using System;
using Microsoft.AspNetCore.Mvc;
using Warehouses.Models;
using Warehouses.Services;

namespace Warehouses.Controllers.Api
{
    [Route("api/product")]
    public class ProductControllers : Controller
    {
        public IProductService _productService;

        public ProductControllers(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addcount")]
        public int Add([FromBody] int id)
        {
            var product = _productService.GetById(id);

            if (product != null)
            {
                product.Count++;

                return product.Count;

            }

            return 0;
        }

        [HttpPost("subtractcount")]
        public int Subtract([FromBody] int id)
        {
            var product = _productService.GetById(id);

            if (product != null && product.Count > 0)
            {
                product.Count--;

                return product.Count;
            }

            return 0;
        }
    }
}

