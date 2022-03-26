using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbNetcoreApp.Helpers;
using MongoDbNetcoreApp.Models;

namespace MongoDbNetcoreApp.Data
{
    public class DbClient : IDbClient
    {
        private readonly MongoDbConfig _config;
        private readonly IMongoCollection<Feedback> _feedbacks;
        private readonly IMongoCollection<WebsiteTable> _websiteTables;

        public DbClient(IOptions<MongoDbConfig> config)
        {
            _config = config.Value;
            var client = new MongoClient(_config.ConnectionString);
            var database = client.GetDatabase(_config.Database);
            _feedbacks = database.GetCollection<Feedback>(_config.FeedbackCollectionName);
            _websiteTables = database.GetCollection<WebsiteTable>(_config.WebsiteTableCollectionName);

        }

        public IMongoCollection<Feedback> GetFeedbacksCollection() => _feedbacks;

        public IMongoCollection<WebsiteTable> GetWebsiteTablesCollection() => _websiteTables;
        
    }
}
