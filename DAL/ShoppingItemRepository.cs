using DAL.interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        DataContext context;

        public ShoppingItemRepository(DataContext _context)
        {
            context = _context;

        }
        public ShoppingItem FindById(int id)
        {
            return context.ShoppingItems
                .Where(s => s.ShoppingItemId == id)
                .Single();
        }

        public List<ShoppingItem> Get()
        {
            return context.ShoppingItems.ToList();
        }

        public List<ShoppingItem> GetItemsPerShoppingBag(int id)
        {
            return context.ShoppingItems
                .Where(s => s.ShoppingBagId == id)
                .Include(s => s.Product)
                .ToList();
        }

        public void Update(ShoppingItem shoppingItem)
        {
            context.ShoppingItems.Update(shoppingItem);
            context.SaveChanges();
        }

        public void Add(ShoppingItem shoppingItem)
        {
            context.ShoppingItems.Add(shoppingItem);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();

        }

        public void Remove(int id)
        {
            var shoppingItem = context.ShoppingItems.SingleOrDefault(p => p.ShoppingItemId == id);
            context.ShoppingItems.Remove(shoppingItem);
            context.SaveChanges();
        }



        //public void Save(ShoppingItem shoppingItem)
        //{
        //    context.ShoppingItems.Add(shoppingItem);
        //    context.SaveChanges();
        //}
    }
}
