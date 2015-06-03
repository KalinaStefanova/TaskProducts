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
    public class ProductRepository : IProductRepository
    {
        MongoDatabase _database;
        MongoCollection<Product> products;

        public ProductRepository()
        {
            _database = MongoWrapper.GetDatabase();
            products = _database.GetCollection<Product>("product");
        }

        public Product[] GetAllProducts()
        {
            MongoCursor<Product> cursorProducts = products.FindAll();
            List<Product> _products = cursorProducts.ToList<Product>();
            return _products.ToArray();
        }

        public Product GetProduct(int id)
        {
            IMongoQuery query = Query.EQ("productID", id);
            Product product = products.Find(query).FirstOrDefault();

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;

        }

        public Product GetProduct(string name)
        {
            IMongoQuery query = Query.EQ("name", name);
            Product product = products.Find(query).FirstOrDefault();

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        public Product[] GetProducts(string categoryName)
        {
            IMongoQuery query = Query.EQ("categoryName", categoryName);
            Product[] product = products.Find(query).ToArray();

            if (product.Length == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        public bool InsertProduct(Product item)
        {
            try
            {
                WriteConcernResult result = products.Insert(item);
                return true;
            }
            catch (WriteConcernException ec)
            {
                
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            IMongoQuery query = Query.EQ("productID", id);
            if (query == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            WriteConcernResult result = products.Remove(query);
            return result.DocumentsAffected == 1;
        }

        public bool UpdateProduct(Product item)
        {
            IMongoQuery query = Query.EQ("productID", item.productID);
            IMongoUpdate update1 = Update.Set("name", item.name); 

            IMongoUpdate update = Update.Set("name", item.name)
                    .Set("description", item.description)
                    .Set("categoryName", item.categoryName);

            SafeModeResult result = products.Update(query, update);

            return result.UpdatedExisting;

        }
    }
}