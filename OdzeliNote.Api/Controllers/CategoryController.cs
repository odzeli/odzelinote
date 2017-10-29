using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OdzeliNote.Manager.Model;
using OdzeliNote.Manager.Concrete;

namespace OdzeliNote.Api.Controllers
{
    /// <summary>
    /// Управление категориями
    /// </summary>
    public class CategoryController : ApiController
    {
        CategoryManager _categoryManager = new CategoryManager("DefaultConnection");
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
