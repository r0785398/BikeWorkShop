using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Models;
using BLL.interfaces;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkshopForBikes.Controllers
{
    public class HomeController : Controller
    {
        public static int shoppingBagId = 0;
        public static int customerId = 0;

        //Enkel om een customer te kiezen soort login
        ICustomerService service;
        public HomeController(ICustomerService _service)
        {
            service = _service;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {

            Customer customer = null;
            if (customerId > 0)
            {
                //ViewBag.CustomerId = customerID;
                customer = service.FindById(customerId);
                //ViewData["Customer"] = customer;
            }
            else
            {
                customer = service.FindFirst();
                //ViewBag.CustomerId = customerID;
            }
            ViewBag.Customers = service.GetListCustomers();
            

            Random r = new Random();
            int getal = r.Next(1, 5);
            ViewData["PictureNr"] = getal;

            return View(customer);
        }

        public IActionResult ChooseCustomer(int CustomerId)
        {
            customerId = CustomerId;

            return RedirectToAction("Index");
        }


        public IActionResult Test()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
