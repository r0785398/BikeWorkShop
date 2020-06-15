using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace DAL
{
    public class CustomerRepository: ICustomerRepository
    {
        DataContext context;

        public CustomerRepository (DataContext _context)
        {
            context = _context;

        }
        public List<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public List<SelectListItem> GetListCustomers()
        {
            return context.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerId.ToString(),
                Text = c.FullName,
                //Selected = c.CustomerId.Equals(3)
            }).ToList();
        }

        public Customer FindById(int id)
        {
            return context.Customers.Where(c => c.CustomerId == id).Single();
        }

        public int FindFirstId()
        {
            return context.ShoppingBags.Min(c => c.CustomerId);
        }

        public Customer FindFirst()
        {
            return context.Customers.Where(c => c.CustomerId == FindFirstId()).Single();

        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            var customer = context.Customers.SingleOrDefault(p => p.CustomerId == id);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }


    }
}
