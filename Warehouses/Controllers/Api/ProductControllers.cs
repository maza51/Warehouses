﻿using System;
using Microsoft.AspNetCore.Mvc;
using Warehouses.Entities;
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

        [HttpPut("{id:int}")]
        public Product Edit([FromBody] Product product, int id)
        {
            var productInDb = _productService.GetById(id);

            if (productInDb != null)
            {
                productInDb.Count = product.Count;

                return productInDb;
            }

            return new Product();
        }
    }
}

