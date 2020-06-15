using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WorkshopForBikes.Controllers
{
    public class ShoppingItemController : Controller
    {
        IShoppingItemService service;

        public ShoppingItemController(IShoppingItemService _service)
        {
            service = _service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(ShoppingItem shoppingItem)
        {

           
            return View();
        }
    }
}