using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WorkshopForBikes.Controllers
{

    public class ShoppingBagController : Controller
    {
        IShoppingBagService serviceShoppingBag;
       
        public ShoppingBagController(IShoppingBagService _service)
        {
            serviceShoppingBag = _service;
        }


        public IActionResult Index()
        {
            List<ShoppingBag> shoppingBags = null;

            if (HomeController.customerId>0)
            {
                shoppingBags = serviceShoppingBag.GetBagsPerCustomer(HomeController.customerId);

            }
            else
            {
                
                shoppingBags = serviceShoppingBag.GetAllShoppingBags();
            }

            return View(shoppingBags);



        }

        public IActionResult Create( int productId, int qty)
        {
            shoppingBagViewModel bag = serviceShoppingBag.AddItemToShoppingBag(HomeController.shoppingBagId, HomeController.customerId, productId, qty);
            HomeController.shoppingBagId = bag.shoppingBag.ShoppingBagId;
                        

            //Go to View Edit
            return RedirectToAction("Edit", new { HomeController.shoppingBagId });

            

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("CustomerId, Date")] ShoppingBag shoppingBag)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        serviceShoppingBag.Add(shoppingBag);
        //        return RedirectToAction("Index");
        //    }
        //    return View(shoppingBag);
        //}


        public IActionResult Edit(int shoppingBagId)
        {
            //shoppingBagId = 8;

            if ( shoppingBagId > 0)
            {
                ViewBag.Customers = serviceShoppingBag.GetListCustomers();
                shoppingBagViewModel shoppingBag = serviceShoppingBag.FindShoppingBagWithItems(shoppingBagId);

                return View(shoppingBag);
            }
                        
            
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int ShoppingBagId, [Bind("ShoppingBagId", "CustomerId", "CustomerId", "Date")] ShoppingBag shoppingBag)
        {
            if (ModelState.IsValid)
            {

                serviceShoppingBag.Update(shoppingBag);
                return RedirectToAction("Index");
            }
            return View(shoppingBag);
        }


    }
}