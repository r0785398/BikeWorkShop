
using BLL.interfaces;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserService: IUserService
    {
        IUserRepository repository;

        public UserService(IUserRepository _repository)
        {
            repository = _repository;
        }

        public List<User> GetAllUsers()
        {
            return repository.Get();
        }

        public void Save(User user)
        {
            repository.Save(user);
        }
    }
}
