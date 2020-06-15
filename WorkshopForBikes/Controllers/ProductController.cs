using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WorkshopForBikes.Controllers
{
    public class ProductController : Controller
    {
        public static int productQty = 0;

        IProductService service;

        public ProductController(IProductService _service)
        {
            service = _service;
        }

        public IActionResult Index(int? shoppingBagId, int? customerId)
        {
            if (shoppingBagId!=null || shoppingBagId<1)
            {
                HomeController.shoppingBagId = shoppingBagId.Value;
            }
            if (customerId!=null || customerId<1)
            {
                HomeController.customerId = customerId.Value;
            }

            List<Product> products = service.GetAllProducts();
            //products.OrderBy(p => p.Name);
            //ViewData["products"] = products;
            
            return View(products);
        }



        public IActionResult Create()
        {
            return View();
        }

        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductId, Name, Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                service.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int productId)
        {
            Product product = service.FindById(productId);
            return View(product);
        }


        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int ProductID, [Bind("ProductId, Name, Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");

            }
            return View(product);
        }


        public IActionResult Remove(int productId)
        {

            service.Remove(productId);
            return RedirectToAction("Index");
        }

        public IActionResult BuyProduct(int productId, int? shoppingBagId)
        {
            Product product = service.FindById(productId);
            ViewData["shoppingBagId"] = shoppingBagId;
            ViewData["productQty"] = 0;

            return View(product);
        }


        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuyProduct(int ProductID, int qty, [Bind("ProductId, Name, Price")] Product product)
        {
            int customerId = 0;

            if (HomeController.customerId>0)
            {
                customerId = HomeController.customerId;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Create", "ShoppingBag", new { ProductID, qty });
            }
            return View(product);
        }


        //public IActionResult SpecificProduct(int productId)
        //{

        //    Product product = service.FindById(productId);


        //    //List<Product> products = service.GetAllProducts();
        //    //ViewData["ProductId"] = productId;


        //    return View(product);
        //}
    }
}