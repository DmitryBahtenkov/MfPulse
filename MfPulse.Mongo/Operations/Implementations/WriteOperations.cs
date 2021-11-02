using System;
using System.Threading.Tasks;
using MfPulse.Mongo.Document;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations.Abstractions;
using MfPulse.Mongo.Security;
using MongoDB.Driver;

namespace MfPulse.Mongo.Operations.Implementations
{
    public class WriteOperations<TDocument> : BaseOperations<TDocument>, IWriteOperations<TDocument> where TDocument : IDocument
    {
        public WriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
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
            return await ExecuteOperation(
                async x => await Collection.FindOneAndDeleteAsync<TDocument>(x),
                F.ById(document.Id)
                );
        }

        public async Task<TDocument> SafeDelete(TDocument document)
        {
            var update = U.Set(x => x.IsArchived, true);
            return await ExecuteOperation(
                async x => await Collection.FindOneAndUpdateAsync<TDocument>(x, update),
                F.ById(document.Id)
            );
        }

        public async Task<TDocument> Upsert(TDocument document)
        {
            document.CreatedAt ??= DateTime.UtcNow;
            var options = new FindOneAndReplaceOptions<TDocument>
            {
                IsUpsert = true
            };
            return await ExecuteOperation(
                async x => await Collection.FindOneAndReplaceAsync(x, document, options),
                F.ById(document.Id)
            );
        }
        
        protected async Task<TDocument> UpdateOne(FilterDefinition<TDocument> filter,
            UpdateDefinition<TDocument> update)
        {
            return await ExecuteOperation(
                async x => await Collection.FindOneAndUpdateAsync<TDocument>(x, update),
                filter);
        }
        
        protected async Task UpdateMany(FilterDefinition<TDocument> filter,
            UpdateDefinition<TDocument> update)
        {
            await ExecuteOperation(
                async x => await Collection.UpdateManyAsync(x, update),
                filter);
            
        }
    }
}