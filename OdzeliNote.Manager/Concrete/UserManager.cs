using System;
using System.Linq;
using OdzeliNote.Manager.Model;
using OdzeliNote.Repository;
using OdzeliNote.Manager.Abstract;

namespace OdzeliNote.Manager.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly string _connectionString;

        public UserManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User GetUser(Guid id)
        {
            using (var context = new UserContext(_connectionString))
            {
                var contextUser = context.User.ToList();
                var user = contextUser.Where(u => u.Id == id).Select(u => new User()
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
