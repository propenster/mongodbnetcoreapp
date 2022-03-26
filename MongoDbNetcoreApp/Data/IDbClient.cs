using MongoDB.Driver;
using MongoDbNetcoreApp.Models;

namespace MongoDbNetcoreApp.Data
{
    public interface IDbClient
    {
        IMongoCollection<Feedback> GetFeedbacksCollection();
        IMongoCollection<WebsiteTable> GetWebsiteTablesCollection();

    }
}
