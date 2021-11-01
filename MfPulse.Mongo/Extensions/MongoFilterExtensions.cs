using MfPulse.Mongo.Document;
using MongoDB.Driver;

namespace MfPulse.Mongo.Extensions
{
    public static class MongoFilterExtensions
    {
        public static FilterDefinition<TDocument> ById<TDocument>(
            this FilterDefinitionBuilder<TDocument> builder, string id)
            where TDocument : IDocument
        {
            return builder.Eq(x => x.Id, id);
        }
    }
}