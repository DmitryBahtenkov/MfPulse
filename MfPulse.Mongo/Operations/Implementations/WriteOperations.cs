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
            return await Collection.FindOneAndDeleteAsync<TDocument>(GetIdFilter(document.Id));
        }

        public async Task<TDocument> SafeDelete(TDocument document)
        {
            var update = U.Set(x => x.IsArchived, true);
            return await Collection.FindOneAndUpdateAsync<TDocument>(GetIdFilter(document.Id), update);
        }

        public async Task<TDocument> Upsert(TDocument document)
        {
            document.CreatedAt ??= DateTime.UtcNow;
            var options = new FindOneAndReplaceOptions<TDocument>
            {
                IsUpsert = true
            };
            return await Collection.FindOneAndReplaceAsync(GetIdFilter(document.Id), document, options);
        }
        
        protected async Task<TDocument> UpdateOne(FilterDefinition<TDocument> filter,
            UpdateDefinition<TDocument> update)
        {
            filter &= _mongoSecurityFilter.GetSecureFilter(filter);

            await Collection.UpdateOneAsync(filter, update);
            return await (await Collection.FindAsync(filter)).FirstOrDefaultAsync();
        }
        
        protected async Task UpdateMany(FilterDefinition<TDocument> filter,
            UpdateDefinition<TDocument> update)
        {
            filter &= _mongoSecurityFilter.GetSecureFilter(filter);

            await Collection.UpdateManyAsync(filter, update);
        }

        protected FilterDefinition<TDocument> GetIdFilter(string id)
        {
            return _mongoSecurityFilter.GetSecureFilter(F.ById(id));
        }
    }
}