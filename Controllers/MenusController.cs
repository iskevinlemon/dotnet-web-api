using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Menus_API.Controllers
{
    [ApiController]
    [Route("/api/menus")]
    public class MenusController : ControllerBase
    {

        [HttpGet(Name = "GetMenus")]
        public IEnumerable<Menu> Get()
        {
            // Implementation to generate menu items
            // Populate with sample data
            var menus = new List<Menu>
            {
                new Menu { Id = 1, Name = "Breakfast Menu", Price = 10.99, Category = "Breakfast" },
                new Menu { Id = 2, Name = "Lunch Menu", Price = 15.99, Category = "Lunch" },
                new Menu { Id = 3, Name = "Dinner Menu", Price = 20.99, Category = "Dinner" }
                // Add more menu items as needed
            };

            return menus;
        }
    }

    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }
}
