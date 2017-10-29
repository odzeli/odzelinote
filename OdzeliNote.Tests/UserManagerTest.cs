using System;
using OdzeliNote.Repository;
using OdzeliNote.Manager.Concrete;
using OdzeliNote.Manager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdzeliNote.Tests
{
    [TestClass]
    public class UserManagerTest
    {
        [TestMethod]
        public void CreateUser()
        {
            var userManager = new UserManager("DefaultConnection");
            var user = new User()
            {
                Name = "Magomed",
                Id = Guid.Empty
            };
            var userMaga = userManager.Create(user);
            Assert.AreEqual(userMaga.Name, user.Name);
        }

        [TestMethod]
        public void GetUserTest()
        {
            var userManager = new UserManager("DefaultConnection");
            var user = new User()
            {
                Name = "Magomed",
                Id = Guid.Empty
            };
            var userMaga = userManager.Create(user);
            var gettingUser = userManager.GetUser(userMaga.Id);
            Assert.AreEqual(userMaga.Name, gettingUser.Name);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var userManager = new UserManager("DefaultConnection");
            var user = new User()
            {
                Name = "Magomed",
                Id = Guid.Empty
            };
            var userMaga = userManager.Create(user);
           var userId = userManager.Delete(userMaga.Id);
            var gettingUser = userManager.GetUser(userId);
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
