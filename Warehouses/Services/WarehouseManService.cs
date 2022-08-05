using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouses.Data;
using Warehouses.Entities;
using Microsoft.AspNetCore.Http;

namespace Warehouses.Services
{
    public class WarehouseManService : IWarehouseManService
    {
        private AppDbContext _dbContext;

        public WarehouseManService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<WarehouseMan>> GetAllAsync()
        {
            return await _dbContext.WarehouseMans.ToListAsync();
        }
        
        public async Task<List<WarehouseMan>> GetAllFreeAsync()
        {
            var all = await this.GetAllAsync();
            return all
                .Where(x => DateTime.Now.AddSeconds(-600) > x.LastTimeBusy)
                .ToList();
        }

        public async Task<WarehouseMan> GetByIdAsync(int id)
        {
            return await _dbContext.WarehouseMans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateBusyAsync(int id)
        {
            var man = await _dbContext.WarehouseMans.FirstOrDefaultAsync(x => x.Id == id);

            if (man != null)
            {
                man.LastTimeBusy = DateTime.Now;
            }

            _dbContext.WarehouseMans.Update(man);
            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> UpdateAsync(WarehouseMan warehouseMan)
        {
            _dbContext.WarehouseMans.Update(warehouseMan);
            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}

