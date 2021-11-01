using MfPulse.Mongo.Document;
using MfPulse.Mongo.Security;
using MongoDB.Driver;

namespace MfPulse.Mongo.Operations.Implementations
{
    public abstract class BaseOperations<TDocument> where TDocument : IDocument
    {
        protected FilterDefinitionBuilder<TDocument> F => Builders<TDocument>.Filter;
        protected UpdateDefinitionBuilder<TDocument> U => Builders<TDocument>.Update;
        protected readonly MongoSecurityFilter _mongoSecurityFilter;

        protected readonly IMongoCollection<TDocument> Collection;
        
        protected BaseOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter)
        {
            _mongoSecurityFilter = mongoSecurityFilter;
            Collection = dbContext.Database.GetCollection<TDocument>(typeof(TDocument).Name.Replace("Document", ""));
        }
    }
}