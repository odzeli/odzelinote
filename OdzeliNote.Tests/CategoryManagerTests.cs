using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdzeliNote.Manager.Concrete;
using OdzeliNote.Repository;


namespace OdzeliNote.Tests
{
    [TestClass]
    public class CategoryManagerTests
    {
        [TestMethod]
        public void CreateCategory()
        {
            var categoryManager = new CategoryManager("DefaultConnection");
            var category = new Manager.Model.Category()
            {
                Name = "Magomed",
                Id = Guid.Empty,
                UserId = Guid.Parse("7D900474-7EB3-E711-8302-AC9E17413A67")
            };
            var categorytwo = categoryManager.Create(category);
            Assert.AreEqual(categorytwo.Name, category.Name);
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            var categoryManager = new CategoryManager("DefaultConnection");
            var category = new Manager.Model.Category()
            {
                Name = "Magomed",
                Id = Guid.Empty,
                UserId = Guid.Parse("7D900474-7EB3-E711-8302-AC9E17413A67")
            };
            var categoryMaga = categoryManager.Create(category);
            var categoryId = categoryManager.Delete(categoryMaga.Id);
            var gettingCategory = categoryManager.GetUserCategories(category.UserId);
            Assert.AreEqual(gettingCategory, null);
        }

        [TestCleanup]
        public void CleanTests()
        {
            using (var context = new UserContext("DefaultConnection"))
            {
                foreach (var category in context.Category)
                {
                    context.Category.Remove(category);
                }
                context.SaveChanges();
            }
        }
    }
}
