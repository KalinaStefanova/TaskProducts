using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

using ProductsAndCategories.Models;
using System.Web.Http;
using System.Net;


namespace ProductsAndCategories.Repositories
{
    public class CategoryRepository : ICategoryRepository   
    {
        MongoDatabase _database;
        MongoCollection<Category> categories;

        public CategoryRepository()
        {
            _database = MongoWrapper.GetDatabase();
            categories = _database.GetCollection<Category>("categories");
        }

        public Category[] GetAllCategories()
        {
            MongoCursor<Category> cursorCategory = categories.FindAll();
            List<Category> _categories = cursorCategory.ToList<Category>();
            return _categories.ToArray();
        }

        public Category GetCategory(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            Category category = categories.Find(query).FirstOrDefault();

            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return category;
        }


        public bool AddCategory(Category item)
        {
            try
            {
                SafeModeResult result = categories.Insert(item);
                return true;
            }
            catch(WriteConcernException ec)
            {

            }
            catch (Exception ex)
            {
               
            }
            return false;
        }

        public bool RemoveCategory(string id)
        {
           
            IMongoQuery query = Query.EQ("_id", id);
            if (query == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            SafeModeResult result = categories.Remove(query);
            return result.DocumentsAffected == 1;
        }

        public bool UpdateCategory(string id, Category item)
        {
            IMongoQuery query = Query.EQ("_id", id);
            IMongoUpdate update = Update
                .Set("name", item._id)
                .Set("description", item.description);

            SafeModeResult result = categories.Update(query, update);

            return result.UpdatedExisting;
        }
    }
}