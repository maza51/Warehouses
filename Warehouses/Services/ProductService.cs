using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouses.Data;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public class ProductService : IProductService
    {
        private AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetByWareHouseIdAsync(int id)
        {
            return await _dbContext.Products.Where(x => x.WarehouseId == id).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            var saved = await _dbContext.SaveChangesAsync();

            return saved > 0;
        }
    }
}

