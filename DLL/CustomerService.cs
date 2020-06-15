using BLL.interfaces;
using DAL.interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomerService: ICustomerService
    {


        ICustomerRepository repository;

        public CustomerService(ICustomerRepository _repository)
        {
            repository = _repository;
        }

        public List<Customer> GetAllCustomers()
        {
            return repository.Get();
        }

        public List<SelectListItem> GetListCustomers()
        {
            return repository.GetListCustomers();
        }

        public Customer FindById(int id)
        {
            return repository.FindById(id);
        }

        public Customer FindFirst()
        {
            return repository.FindFirst();
        }

        public void Update(Customer customer)
        {
            repository.Update(customer);
        }

        public void Add(Customer customer)
        {
            repository.Add(customer);
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }


    }
}
