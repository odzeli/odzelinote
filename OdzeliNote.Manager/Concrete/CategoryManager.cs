using System;
using System.Linq;
using OdzeliNote.Repository;
using OdzeliNote.Manager.Model;
using System.Collections.Generic;

namespace OdzeliNote.Manager.Concrete
{
    public class CategoryManager
    {
        string _connectionString;
        public CategoryManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Category Create(Category category)
        {
            using (var context = new UserContext(_connectionString))
            {
                var newCategory = new Repository.Model.Category()
                {
                    Name = category.Name,
                    UserId = category.UserId,
                    NoteId = category.NoteId
                };
                context.Category.Add(newCategory);
                context.SaveChanges();
                return new Category()
                {
                    UserId = newCategory.UserId,
                    Name = newCategory.Name,
                    NoteId = newCategory.NoteId
                };
            }
        }

        public Guid Delete(Guid id)
        {
            using (var context = new UserContext(_connectionString))
            {
                var category = context.Category.Where(u => u.Id == id).Select(u => new Repository.Model.Category()
                {
                    Name = u.Name,
                    UserId = u.UserId,
                    NoteId = u.NoteId
                }).FirstOrDefault();
                context.Category.Remove(category);
                return id;
            }
        }

        public List<Category> GetUserCategories(Guid userId)
        {
            using (var context = new UserContext(_connectionString))
            {
                var user = context.Category.Where(u => u.UserId == userId).Select(u => new Category()
                {
                    Name = u.Name,
                    UserId = u.UserId,
                    NoteId = u.NoteId
                }).ToList();
                return user;
            }
        }

    }
}
