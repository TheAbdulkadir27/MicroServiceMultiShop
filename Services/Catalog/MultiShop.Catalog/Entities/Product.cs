using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string İmageUrl { get; set; }
        public string Description { get; set; }


        public string CategoryID { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}
