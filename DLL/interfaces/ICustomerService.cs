using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();

        List<SelectListItem> GetListCustomers();

        Customer FindById(int id);

        Customer FindFirst();

        void Update(Customer customer);

        void Add(Customer customer);

        void Remove(int id);

    }
}
