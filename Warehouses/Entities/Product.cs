﻿using System;
namespace Warehouses.Entities
{
	public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public int WarehouseId { get; set; }
	}
}

