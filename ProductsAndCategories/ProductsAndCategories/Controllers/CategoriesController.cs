using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsAndCategories.Models;
using ProductsAndCategories.Repositories;

namespace ProductsAndCategories.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoryRepository categoryRepository;

        public CategoriesController()
        {
            this.categoryRepository = new CategoryRepository();

        }
        // GET: api/Categories
        public Category[] Get()
        {
            return categoryRepository.GetAllCategories();
        }

        // GET: api/Categories/5
        public Category Get(string id)
        {
            return categoryRepository.GetCategory(id);
        }

        // POST: api/Categories
        public bool Post(Category category)
        {
           bool result = categoryRepository.AddCategory(category);
           return result;
        }

        public void Put(string id, Category value)
        {
            if (!categoryRepository.UpdateCategory(id, value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }

        // DELETE: api/Categories/5
        public void Delete(string id)
        {
            categoryRepository.RemoveCategory(id);
        }
    }
}
