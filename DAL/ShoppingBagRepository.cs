using DAL.interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ShoppingBagRepository : IShoppingBagRepository
    {
        DataContext context;

        public ShoppingBagRepository(DataContext _context)
        {
            context = _context;

        }
        public ShoppingBag FindById(int id)
        {
            return context.ShoppingBags
                .Where(s => s.ShoppingBagId == id)
                .Include(s => s.Customer)
                .Single();
        }



        public int FindLastId()
        {
            return context.ShoppingBags.Max(s => s.ShoppingBagId);
        }

        public List<ShoppingBag> Get()
        {
            return context.ShoppingBags
                .Include(x => x.Customer)
                .ToList();
        }

        public List<ShoppingBag> GetBagsPerCustomer(int customerId)
        {
            return context.ShoppingBags
                .Where(b => b.CustomerId == customerId)
                .Include(x => x.Customer)
                .ToList();
        }

        public void Update(ShoppingBag shoppingBag)
        {
            context.ShoppingBags.Update(shoppingBag);
            context.SaveChanges();
        }

        public void Add(ShoppingBag shoppingBag)
        {
            context.ShoppingBags.Add(shoppingBag);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            var shoppingBag = context.ShoppingBags.SingleOrDefault(p => p.ShoppingBagId == id);
            context.ShoppingBags.Remove(shoppingBag);
            context.SaveChanges();
        }

        //public void Save(ShoppingBag shoppingBag)
        //{
        //    context.ShoppingBags.Add(shoppingBag);
        //    context.SaveChanges();
        //}
    }
}
