using System.Security.Principal;
using MfPulse.Mongo.Document;
using MongoDB.Driver;

namespace MfPulse.Mongo.Security
{
    public class MongoSecurityFilter
    {
        private readonly IMongoIdentity _mongoIdentity;

        public MongoSecurityFilter(IMongoIdentity mongoIdentity)
        {
            _mongoIdentity = mongoIdentity;
        }

        public FilterDefinition<TDocument> GetSecureFilter<TDocument>(FilterDefinition<TDocument> filter) where TDocument : IDocument
        {
            var documentType = typeof(TDocument);
            var result = filter;
            
            var builder = Builders<TDocument>.Filter;

            if (typeof(IDocumentWithUserId).IsAssignableFrom(documentType) && !string.IsNullOrEmpty(_mongoIdentity.UserId))
            {
                result &= builder.Eq(nameof(IDocumentWithUserId.UserId), _mongoIdentity.UserId);
            }

            if (typeof(IDocumentWithCompanyId).IsAssignableFrom(documentType) && !string.IsNullOrEmpty(_mongoIdentity.CompanyId))
            {
                result &= builder.Eq(nameof(IDocumentWithCompanyId.CompanyId), _mongoIdentity.CompanyId);
            }

            return result;
        }
    }
}