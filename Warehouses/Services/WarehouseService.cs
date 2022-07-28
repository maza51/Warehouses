using System;
using System.Collections.Generic;
using System.Linq;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public class WarehouseService : IWarehouseService
    {
        private IProductService _productService;

        private List<Warehouse> _warehouses;

        public WarehouseService(IProductService productService)
        {
            _productService = productService;

            _warehouses = new List<Warehouse>
            {
                new Warehouse
                {
                    Id = 1,
                    Name = "Склад 1",
                    Products = _productService.GetByWareHouseId(1)
                },

                new Warehouse
                {
                    Id = 2,
                    Name = "Склад 2",
                    Products = _productService.GetByWareHouseId(2)
                }
            };
            _productService = productService;
        }

        public List<Warehouse> GetAll()
        {
            return _warehouses;
        }

        public Warehouse GetById(int id)
        {
            return _warehouses.FirstOrDefault(x => x.Id == id);
        }
    }
}

