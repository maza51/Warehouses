using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetByWareHouseIdAsync(int id);
        Task UpdateAsync(Product product);
    }
}