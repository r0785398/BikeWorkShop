using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
    public interface IProductRepository
    {
        List<Product> Get();

        Product FindById(int id);

        void Update(Product product);

        void Add(Product product);

        void Remove(int id);
    }
}
