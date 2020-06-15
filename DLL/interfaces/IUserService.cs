using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.interfaces
{
    public interface IUserService
    {

        List<User> GetAllUsers();

        void Save(User user);
    }
}
