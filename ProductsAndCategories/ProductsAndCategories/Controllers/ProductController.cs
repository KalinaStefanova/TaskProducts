using MongoDB.Driver;
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
    public class ProductController : ApiController
    {

        private ProductRepository productRepository;

        public ProductController()
        {
            this.productRepository = new ProductRepository();
        }

        // GET: api/Product
        public Product[]  Get()
        {
            return productRepository.GetAllProducts();
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return productRepository.GetProduct(id);
        }

        // GET: api/product/name
        [Route("api/product/name")]
        [HttpGet]
        public Product Get(string name)
        {
            return productRepository.GetProduct(name);     
        }

        // GET: api/product/category/?categoryName=fruits
        [Route("api/product/category")]
        [HttpGet]
        public Product[] GetProducts(string categoryName)
        {
            return productRepository.GetProducts(categoryName);
        }

        // POST: api/Product
        public void Post(Product product)
        {
            productRepository.InsertProduct(product);
        }

        public void Put(Product product)
        {
            productRepository.UpdateProduct(product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            productRepository.DeleteProduct(id);
        }
    }
}
