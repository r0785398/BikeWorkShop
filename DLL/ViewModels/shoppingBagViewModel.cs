using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
   public  class shoppingBagViewModel
    {
        public ShoppingBag shoppingBag;
        public List<ShoppingItem> shoppingItems;
        public shoppingBagViewModel()
        {
            shoppingItems = new List<ShoppingItem>();
        }
    }
}
