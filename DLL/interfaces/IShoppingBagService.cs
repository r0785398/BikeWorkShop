using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
    public interface IShoppingBagService
    {
        List<ShoppingBag> GetAllShoppingBags();

        List<ShoppingBag> GetBagsPerCustomer(int customerId);

        List<SelectListItem> GetListCustomers();

        ShoppingBag FindById(int id);

        int FindLastId();

        void Update(ShoppingBag shoppingBag);

        void Add(ShoppingBag shoppingBag);

        void Remove(int id);

        shoppingBagViewModel AddItemToShoppingBag(int shoppingBagId, int customerId, int productId, int qty);

        shoppingBagViewModel FindShoppingBagWithItems(int id);

    }
}
