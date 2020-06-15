using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.interfaces
{
    public interface IShoppingItemRepository
    {
        List<ShoppingItem> Get();

        List<ShoppingItem> GetItemsPerShoppingBag(int id);

        ShoppingItem FindById(int id);

        void Update(ShoppingItem shoppingItem);

        void Add(ShoppingItem shoppingItem);

        void Remove(int id);
    }
}
