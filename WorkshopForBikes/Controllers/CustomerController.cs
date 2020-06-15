using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WorkshopForBikes.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService service;

        public CustomerController(ICustomerService _service)
        {
            service = _service;
        }
     

        public IActionResult Index()
        {
            List<Customer> customers = service.GetAllCustomers();

            return View(customers);
        }

        
        
        public IActionResult Create()
        {
            return View();
        }
        
        
        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId, FirstName, Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                service.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }



        public IActionResult Edit(int customerId)
        {

            Customer customer = service.FindById(customerId);
            return View(customer);
        }


        //Post:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int CustomerId, [Bind("CustomerId, FirstName, Name")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");

            }
            return View(customer);
        }


        public IActionResult Remove(int customerId)
        {

            service.Remove(customerId);
            return RedirectToAction("Index");
        }


    }
}