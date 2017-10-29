using System.Collections.Generic;
using System.Linq;
using OdzeliNote.Manager.Model;
using OdzeliNote.Repository;
using System;

namespace OdzeliNote.Manager.Concrete
{
    public class UserManager
    {
        string _connectionString;

        public UserManager(string connectionString)
        {
            _connectionString = connectionString;
        }

       
        public User GetUser(Guid id)
        {
            using (var context = new UserContext(_connectionString))
            {
                var user = context.User.Where(u => u.Id == id).Select(u => new User()
                {
                    Id = u.Id,
                    Name = u.Name
                }).FirstOrDefault();
                return user;
            }
        }
        public User Create(User user)
        {
            using (var context = new UserContext(_connectionString))
            {
                var newUser = new Repository.Model.User()
                {
                    Name = user.Name
                };
                context.User.Add(newUser);
                context.SaveChanges();
                return new User()
                {
                    Id = newUser.Id,
                    Name = newUser.Name
                };
            }
        }

        public Guid Delete(Guid id)
        {
            using (var context = new UserContext(_connectionString))
            {
                var user = context.User.Where(u => u.Id == id).FirstOrDefault();
                context.User.Remove(user);
                context.SaveChanges();
                return id;
            }
        }

    }
}
