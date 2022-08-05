using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouses.Data;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public class HistoryService : IHistoryService
    {
        public AppDbContext _dbContext;

        public HistoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<History>> GetAllAsync()
        {
            return await _dbContext.Historyes.ToListAsync();
        }

        public async Task<bool> CreateAsync(History history)
        {
            await _dbContext.Historyes.AddAsync(history);
            var saved = await _dbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}

