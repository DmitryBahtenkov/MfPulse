using System;
using System.Threading.Tasks;
using MfPulse.Mongo.Document;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations.Abstractions;
using MongoDB.Driver;

namespace MfPulse.Mongo.Operations.Implementations
{
    public class WriteOperations<TDocument> : BaseOperations<TDocument>, IWriteOperations<TDocument> where TDocument : IDocument
    {
        public WriteOperations(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TDocument> Insert(TDocument document)
        {
            document.CreatedAt = DateTime.UtcNow;
            await Collection.InsertOneAsync(document);
            return document;
        }

        public async Task<TDocument> Delete(TDocument document)
        {
            return await Collection.FindOneAndDeleteAsync<TDocument>(F.ById(document.Id));
        }

        public async Task<TDocument> SafeDelete(TDocument document)
        {
            var update = U.Set(x => x.IsArchived, true);
            return await Collection.FindOneAndUpdateAsync<TDocument>(F.ById(document.Id), update);
        }

        public async Task<TDocument> Upsert(TDocument document)
        {
            document.CreatedAt ??= DateTime.UtcNow;
            var options = new FindOneAndReplaceOptions<TDocument>
            {
                IsUpsert = true
            };
            return await Collection.FindOneAndReplaceAsync(F.ById(document.Id), document, options);
        }
        
        protected async Task<TDocument> UpdateOne(FilterDefinition<TDocument> filter,
            UpdateDefinition<TDocument> update)
        {
            return await Collection.FindOneAndUpdateAsync<TDocument>(filter, update);
        }
        
        protected async Task UpdateMany(FilterDefinition<TDocument> filter,
            UpdateDefinition<TDocument> update)
        {
            await Collection.UpdateManyAsync(filter, update);
        }
    }
}