using MfPulse.Mongo.Document;
using MongoDB.Driver;

namespace MfPulse.Mongo.Operations.Implementations
{
    public abstract class BaseOperations<TDocument> where TDocument : IDocument
    {
        protected FilterDefinitionBuilder<TDocument> F => Builders<TDocument>.Filter;
        protected UpdateDefinitionBuilder<TDocument> U => Builders<TDocument>.Update;

        protected readonly IMongoCollection<TDocument> Collection;
        
        protected BaseOperations(DbContext dbContext)
        {
            Collection = dbContext.Database.GetCollection<TDocument>(typeof(TDocument).Name.Replace("Document", ""));
        }
    }
}