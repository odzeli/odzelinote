using System;
using OdzeliNote.Repository;
using OdzeliNote.Manager.Concrete;
using OdzeliNote.Manager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdzeliNote.Manager.Abstract;

namespace OdzeliNote.Tests
{
    [TestClass]
    public class UserManagerTest
    {
        private readonly IUserManager _usersManager;
        private readonly string _connectinString;

        public UserManagerTest()
        {
            _connectinString = "DefaultConnection";
            _usersManager = new UserManager(_connectinString);
        }

        [TestMethod]
        public void CreateUser()
        {
            var user = new User()
            {
                Name = "Magomed",
                Id = Guid.Empty
            };
            var userMaga = _usersManager.Create(user);
            Assert.AreEqual(userMaga.Name, user.Name);
        }

        [TestMethod]
        public void GetUserTest()
        {
            var user = new User()
            {
                Name = "Magomed",
                Id = Guid.Empty
            };
            var userMaga = _usersManager.Create(user);
            var gettingUser = _usersManager.GetUser(userMaga.Id);
            Assert.AreEqual(userMaga.Name, gettingUser.Name);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var user = new User()
            {
                Name = "Magomed",
                Id = Guid.Empty
            };
            var userMaga = _usersManager.Create(user);
           var userId = _usersManager.Delete(userMaga.Id);
            var gettingUser = _usersManager.GetUser(userId);
            Assert.AreEqual(gettingUser, null);
        }

        [TestCleanup]
        public void CleanData()
        {
            using (var context = new UserContext("DefaultConnection"))
            {
                foreach (var user in context.User)
                {
                    if (user.Id != Guid.Parse("7D900474-7EB3-E711-8302-AC9E17413A67"))
                    {
                        context.User.Remove(user);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
