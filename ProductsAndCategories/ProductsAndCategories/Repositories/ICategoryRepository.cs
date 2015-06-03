using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsAndCategories.Models;


namespace ProductsAndCategories.Repositories
{
    interface ICategoryRepository
    {
        Category[] GetAllCategories();

        Category GetCategory(string id);

       // Category AddCategory(Category item);
        bool AddCategory(Category item);

        bool RemoveCategory(string id);

        bool UpdateCategory(string id, Category item);
    }
}
