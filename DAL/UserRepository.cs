using Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UserRepository: IUserRepository
    {
        //private List<User> users;
        DataContext context;

        public UserRepository(DataContext _context)
        {
            //users = new List<User>();
            //users.Add(new User() { Id = 1, Name = "Peeters" });
            //users.Add(new User() { Id = 2, Name = "Semts" });
            //users.Add(new User() { Id = 4, Name = "Verlinden" });

            context = _context;
        }

        public List<User> Get()
        {
            return context.Users.ToList();
        }

        public User FindById(int id)
        {
            return context.Users.Where(u => u.Id == id).Single();
        }

        public void Save(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

    }
}
