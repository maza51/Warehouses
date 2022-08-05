using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public interface IWarehouseManService
    {
        Task<List<WarehouseMan>> GetAllAsync();
        Task<List<WarehouseMan>> GetAllFreeAsync();
        Task<WarehouseMan> GetByIdAsync(int id);
        Task<bool> UpdateBusyAsync(int id);
        Task<bool> UpdateAsync(WarehouseMan warehouseMan);
    }
}