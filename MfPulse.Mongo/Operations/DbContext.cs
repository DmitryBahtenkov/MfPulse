using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MfPulse.Mongo.Operations
{
    public class DbContext
    {
        public IMongoDatabase Database { get; }
        
        public DbContext(IConfiguration configuration)
        {
            var connection = configuration["MongoConnection"];
            var database = configuration["MongoDatabase"];
            var client = new MongoClient(connection);
            Database = client.GetDatabase(database);
        }
    }
}