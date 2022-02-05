using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineRetailStore.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ItemId")]
        public int ItemId { get; set; }

        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemPrice { get; set; }
    }
}
