using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAndCategories.Models
{
    public class Product
    {
       // public int _id { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        public int productID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string image {get; set; }

      //  public int categoryID { get; set; }

        public string categoryName { get; set; }
    }
}