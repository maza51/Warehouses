using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public interface IWarehouseService
    {
        Task<List<Warehouse>> GetAllAsync();
        Task<Warehouse> GetByIdAsync(int id);
    }
}