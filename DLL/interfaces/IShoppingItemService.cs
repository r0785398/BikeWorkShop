using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
    public interface IShoppingItemService
    {
        List<ShoppingItem> GetAllShoppingItems();

        List<ShoppingItem> GetItemsPerShoppingBag(int id);

        ShoppingItem FindById(int id);

        void Update(ShoppingItem shoppingItem);

        void Add(ShoppingItem shoppingItem);

        void Remove(int id);
    }
}
