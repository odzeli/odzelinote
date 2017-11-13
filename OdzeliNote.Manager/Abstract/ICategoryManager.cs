using OdzeliNote.Manager.Model;
using System;
using System.Collections.Generic;

namespace OdzeliNote.Manager.Abstract
{
    public interface ICategoryManager
    {
        Category Create(Category category);

        Guid Delete(Guid id);

        List<Category> GetUserCategories(Guid userId);
    }
}
