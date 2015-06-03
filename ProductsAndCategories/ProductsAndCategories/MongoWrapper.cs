using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAndCategories
{
    public static class MongoWrapper
    {
        public static MongoDatabase GetDatabase()
        {           
            string connectionString = "mongodb://localhost";
            MongoClient _client = new MongoClient(connectionString);
            MongoServer _server = _client.GetServer();
            MongoDatabase _database = _server.GetDatabase("productInfo");

            return _database;
        }
    }
}