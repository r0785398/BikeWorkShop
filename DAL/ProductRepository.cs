using DAL.interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProductRepository : IProductRepository
    {
        DataContext context;

        public ProductRepository(DataContext _context)
        {
            context = _context;

        }
        public Product FindById(int id)
        {

            return context.Products.Where(p => p.ProductId == id).Single();
        }

        public List<Product> Get()
        {
            return context.Products.ToList();
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductId == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

    }
}
