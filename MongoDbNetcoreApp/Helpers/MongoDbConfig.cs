namespace MongoDbNetcoreApp.Helpers
{
    public class MongoDbConfig
    {
         
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string FeedbackCollectionName { get; set; }  
        public string WebsiteTableCollectionName { get; set; }
    }
}
