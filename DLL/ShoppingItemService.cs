using BLL.interfaces;
using DAL.interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ShoppingItemService : IShoppingItemService
    {
        IShoppingItemRepository repository;

        public ShoppingItemService(IShoppingItemRepository _repository)
        {
            repository = _repository;
        }
        public List<ShoppingItem> GetAllShoppingItems()
        {
            return repository.Get();
        }

        public List<ShoppingItem> GetItemsPerShoppingBag(int id)
        {
            return repository.GetItemsPerShoppingBag(id);
        }

        public ShoppingItem FindById(int id)
        {
            return repository.FindById(id);
        }

        public void Update(ShoppingItem shoppingItem)
        {
            repository.Update(shoppingItem);
        }

        public void Add(ShoppingItem shoppingItem)
        {
            repository.Add(shoppingItem);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }
    }
}
