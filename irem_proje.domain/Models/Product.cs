using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.domain.Models
{

    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public double price { get; set; }
        public string size { get; set; }
        public int quantity { get; set; }
        public string category { get; set; }
        public string productName { get; set; }

    }
}
