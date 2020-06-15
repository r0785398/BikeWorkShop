using BLL.interfaces;
using BLL.ViewModels;
using DAL.interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ShoppingBagService : IShoppingBagService
    {
        IShoppingBagRepository repository;
        IShoppingItemRepository shoppingItemRepository;
       
        ICustomerRepository customerRepository;

       
        public ShoppingBagService(IShoppingBagRepository _repository, IShoppingItemRepository _shoppingItemRepository, ICustomerRepository _customerRepository)
        {
            repository = _repository;
            shoppingItemRepository = _shoppingItemRepository;
            customerRepository = _customerRepository;
        }

        public List<ShoppingBag> GetAllShoppingBags()
        {
            return repository.Get();
        }

        public List<ShoppingBag> GetBagsPerCustomer(int customerId)
        {
            return repository.GetBagsPerCustomer(customerId);
        }

        public List<SelectListItem> GetListCustomers()
        {
            return customerRepository.GetListCustomers();
        }

        public ShoppingBag FindById(int id)
        {
            return repository.FindById(id);
        }

        public int FindLastId()
        {
            return repository.FindLastId();
        }


        public void Update(ShoppingBag shoppingBag)
        {
            repository.Update(shoppingBag);
        }

        public void Add(ShoppingBag shoppingBag)
        {
            repository.Add(shoppingBag);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }

        public shoppingBagViewModel AddItemToShoppingBag(int shoppingBagId, int customerId, int productId, int qty)
        {
            ShoppingBag shoppingBag = null; 
            if (shoppingBagId == 0)
            {
                //Create one now ShoppingBag + add to DB + Get ShoppingBagId
                shoppingBag = new ShoppingBag();
                shoppingBag.CustomerId = customerId;
                shoppingBag.Date = DateTime.Now.Date;

                Add(shoppingBag);

                shoppingBagId = FindLastId();
                shoppingBag.ShoppingBagId = shoppingBagId;
                //WorkshopForBikes.HomeController.shoppingBagId = shoppingBagId;
            }
            else
            {
                shoppingBag = FindById(shoppingBagId);
            }

            //Add product to ShoppingItem + add to DB
            ShoppingItem shoppingItem = new ShoppingItem();

            shoppingItem.ShoppingBagId = shoppingBagId;
            shoppingItem.ProductId = productId;
            shoppingItem.Quantity = qty;
            shoppingItemRepository.Add(shoppingItem);

            shoppingBagViewModel bag = new shoppingBagViewModel();
            bag.shoppingBag= shoppingBag;
            bag.shoppingItems.Add(shoppingItem);

            
            return bag;

            // serviceShoppingItem.Add(shoppingItem);
        }

        public shoppingBagViewModel FindShoppingBagWithItems(int id)
        {
            shoppingBagViewModel bag = new shoppingBagViewModel();
            bag.shoppingBag = FindById(id); ;
            bag.shoppingItems = shoppingItemRepository.GetItemsPerShoppingBag(id);

            
            foreach(var item in bag.shoppingItems)
            {
                item.SubTotaal = item.Quantity * item.Product.Price;
                
            }

            bag.shoppingBag.TotaalQty = bag.shoppingItems.Sum(x => x.Quantity);
            bag.shoppingBag.SubTotaal = bag.shoppingItems.Sum(x => x.SubTotaal);

            //Calc. discount

            if (bag.shoppingBag.TotaalQty>6)
            {
                bag.shoppingBag.DisountProcent = 10;
                bag.shoppingBag.DiscountValue = bag.shoppingBag.SubTotaal * bag.shoppingBag.DisountProcent /100;
                bag.shoppingBag.Totaal = bag.shoppingBag.SubTotaal - bag.shoppingBag.DiscountValue;
            }
            else if (bag.shoppingBag.TotaalQty > 3)
            {
                bag.shoppingBag.DisountProcent = 5;
                bag.shoppingBag.DiscountValue = bag.shoppingBag.SubTotaal * bag.shoppingBag.DisountProcent / 100;
                bag.shoppingBag.Totaal = bag.shoppingBag.SubTotaal - bag.shoppingBag.DiscountValue;
            }
            else
            {
                bag.shoppingBag.DiscountValue = 0;
                bag.shoppingBag.Totaal = bag.shoppingBag.SubTotaal;
            }
            return bag;
        }
    }
}
