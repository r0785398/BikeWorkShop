using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product FindById(int id);

        void Update(Product product);

        void Add(Product product);

        void Remove(int id);
    }
}
