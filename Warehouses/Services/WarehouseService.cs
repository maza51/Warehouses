using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouses.Data;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public class WarehouseService : IWarehouseService
    {
        private AppDbContext _dbContext;

        public WarehouseService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Warehouse>> GetAllAsync()
        {
            return await _dbContext.Warehouses
                .Include(x => x.Products)
                .ToListAsync();
        }

        public async Task<Warehouse> GetByIdAsync(int id)
        {
            return await _dbContext.Warehouses
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

