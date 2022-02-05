using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineRetailStore.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("OrderId")]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [BsonElement("ProductId")]
        public int ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderAmount { get; set; }
    }
}
