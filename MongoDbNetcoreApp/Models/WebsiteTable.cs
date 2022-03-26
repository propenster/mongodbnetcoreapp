using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbNetcoreApp.Models
{
    public class WebsiteTable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string DomainName { get; set; }

        public string FormName { get; set; }
    }
}
