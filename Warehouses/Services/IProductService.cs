using System.Collections.Generic;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> GetByWareHouseId(int id);
        void AddCount(int id);
    }
}