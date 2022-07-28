using System.Collections.Generic;
using Warehouses.Entities;

namespace Warehouses.Services
{
    public interface IWarehouseService
    {
        List<Warehouse> GetAll();
        Warehouse GetById(int id);
    }
}