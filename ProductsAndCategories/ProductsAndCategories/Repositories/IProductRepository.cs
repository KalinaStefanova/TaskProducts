using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsAndCategories.Models;
using MongoDB.Bson;

namespace ProductsAndCategories.Repositories
{
    interface IProductRepository
    {
        Product[]  GetAllProducts();

        Product GetProduct(int id);

        Product GetProduct(string name);

        Product[] GetProducts(string categoryName);

        bool InsertProduct(Product item);

        bool DeleteProduct(int id);

        bool UpdateProduct(Product item);
    }
}
