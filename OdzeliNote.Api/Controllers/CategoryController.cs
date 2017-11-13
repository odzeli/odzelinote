using System;
using System.Collections.Generic;
using System.Web.Http;
using OdzeliNote.Manager.Model;
using OdzeliNote.Manager.Concrete;
using OdzeliNote.Manager.Abstract;

namespace OdzeliNote.Api.Controllers
{
    /// <summary>
    /// Управление категориями
    /// </summary>
    public class CategoryController : ApiController
    {
        private readonly string _connectionString;
        private readonly ICategoryManager _categoryManager;
        public CategoryController()
        {
            _connectionString = "DefaultConnection";
            _categoryManager = new CategoryManager(_connectionString);
        }
        /// <summary>
        /// Получить категорию
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <returns></returns>
        [HttpGet]
        public List<Category> Get(Guid categoryId)
        {
            return _categoryManager.GetUserCategories(categoryId);
        }
        /// <summary>
        /// Создание категории
        /// </summary>
        /// <param name="category">Категория</param>
        /// <returns></returns>
        [HttpPost]
        public Category Create(Category category)
        {
            return _categoryManager.Create(category);
        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <returns></returns>
        [HttpDelete]
        public Guid Remove(Guid categoryId)
        {
            return _categoryManager.Delete(categoryId);
        }
    }
}
