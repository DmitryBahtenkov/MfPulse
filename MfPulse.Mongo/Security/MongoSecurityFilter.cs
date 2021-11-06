using System.Security.Principal;
using MfPulse.Mongo.Document;
using MongoDB.Driver;

namespace MfPulse.Mongo.Security
{
    public class MongoSecurityFilter
    {

        public MongoSecurityFilter()
        {
        }

        public FilterDefinition<TDocument> GetSecureFilter<TDocument>(FilterDefinition<TDocument> filter) where TDocument : IDocument
        {
            return FilterDefinition<TDocument>.Empty;
        }
    }
}