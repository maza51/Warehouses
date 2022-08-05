using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public interface IHistoryService
    {
        Task<bool> CreateAsync(History history);
        Task<List<History>> GetAllAsync();
    }
}