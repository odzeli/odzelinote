using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdzeliNote.Manager.Concrete;
using OdzeliNote.Repository;
using OdzeliNote.Manager.Abstract;

namespace OdzeliNote.Tests
{
    [TestClass]
    public class CategoryManagerTests
    {
        private readonly string _connectionString;
        private readonly ICategoryManager _categoryManager;

        public CategoryManagerTests()
        {
            _connectionString = "DefaultConnection";
            _categoryManager = new CategoryManager(_connectionString);
        }

        [TestMethod]
        public void CreateCategory()
        {
            var category = new Manager.Model.Category()
            {
                Name = "Magomed",
                Id = Guid.Empty,
                UserId = Guid.Parse("7D900474-7EB3-E711-8302-AC9E17413A67")
            };
            var categorytwo = _categoryManager.Create(category);
            Assert.AreEqual(categorytwo.Name, category.Name);
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            var category = new Manager.Model.Category()
            {
                Name = "Magomed",
                Id = Guid.Empty,
                UserId = Guid.Parse("7D900474-7EB3-E711-8302-AC9E17413A67")
            };
            var categoryMaga = _categoryManager.Create(category);
            var categoryId = _categoryManager.Delete(categoryMaga.Id);
            var gettingCategory = _categoryManager.GetUserCategories(category.UserId);
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
