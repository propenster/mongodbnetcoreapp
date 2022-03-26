using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbNetcoreApp.Models
{
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMessage { get; set; }
        public string DomainName { get; set; }
        public string FormName { get; set; }
    }
}
