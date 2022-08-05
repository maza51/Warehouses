using System;
using Microsoft.AspNetCore.Mvc;
using Warehouses.Entities;

namespace Warehouses.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return RedirectToAction("Details", "Warehouse", new { id = 1 });
        }
    }
}

