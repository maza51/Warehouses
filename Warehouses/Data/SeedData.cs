using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Collections.Generic;
using Warehouses.Entities;

namespace Warehouses.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider service)
        {
            using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var products = new List<Product>
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

                context.Products.AddRange(products);

                var warehouses = new List<Warehouse>
                {
                    new Warehouse
                    {
                        Id = 1,
                        Name = "Склад 1"
                    },

                    new Warehouse
                    {
                        Id = 2,
                        Name = "Склад 2"
                    }
                };

                context.Warehouses.AddRange(warehouses);

                var warehouseMans = new List<WarehouseMan>
                {
                    new WarehouseMan
                    {
                        Id = 1,
                        LastTimeBusy = DateTime.Now.AddMinutes(-10)
                    },

                    new WarehouseMan
                    {
                        Id = 2,
                        LastTimeBusy = DateTime.Now.AddMinutes(-10)
                    },

                    new WarehouseMan
                    {
                        Id = 3,
                        LastTimeBusy = DateTime.Now.AddMinutes(-10)
                    }
                };

                context.WarehouseMans.AddRange(warehouseMans);

                context.SaveChanges();
            }

        }
    }
}

