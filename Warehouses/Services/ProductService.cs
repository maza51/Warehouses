using System;
using System.Collections.Generic;
using System.Linq;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products { get; set; }

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Морковка", Count = 1, WarehouseId = 1 },

                new Product { Id = 2, Name = "Картошка", Count = 1, WarehouseId = 1 },

                new Product { Id = 3, Name = "Лук", Count = 1, WarehouseId = 1 },

                new Product { Id = 4, Name = "Помидоры", Count = 1, WarehouseId = 1 },

                new Product { Id = 5, Name = "Огурцы", Count = 1, WarehouseId = 1 },

                new Product { Id = 6, Name = "Морковка", Count = 1, WarehouseId = 2 },

                new Product { Id = 7, Name = "Картошка", Count = 1, WarehouseId = 2 },

                new Product { Id = 8, Name = "Лук", Count = 1, WarehouseId = 2 },

                new Product { Id = 9, Name = "Помидоры", Count = 1, WarehouseId = 2 },

                new Product { Id = 10, Name = "Огурцы", Count = 1, WarehouseId = 2 },
            };
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetByWareHouseId(int id)
        {
            return _products.Where(x => x.WarehouseId == id).ToList();
        }

        public void AddCount(int id)
        {
            var product = this.GetById(id);

            if (product != null)
            {
                product.Count++;
            }
        }
    }
}

