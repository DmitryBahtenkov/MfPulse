using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Mongo.Document;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations.Abstractions;
using MfPulse.Mongo.Security;
using MongoDB.Driver;

namespace MfPulse.Mongo.Operations.Implementations
{
    public class GetOperations<TDocument> : BaseOperations<TDocument>, IGetOperations<TDocument> where TDocument : IDocument
    {
        public GetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }
        
        public async Task<List<TDocument>> All(bool isArchived = false)
        {
            return await Many(F.Empty, isArchived);
        }

        public async Task<TDocument> ById(string id)
        {
            return await One(F.ById(id));
        }

        public async Task<List<TDocument>> ByIds(params string[] ids)
        {
            return await Many(F.In(x => x.Id, ids));
        }

        public async Task<bool> ExistById(string id)
        {
            return await Count(F.ById(id)) > 0;
        }

        protected async Task<TDocument> One(FilterDefinition<TDocument> filter, bool isArchived = false)
        {
            filter &= F.Eq(x => x.IsArchived, isArchived);

            return await ExecuteOperation(async x => await (await Collection.FindAsync(x)).FirstOrDefaultAsync(), filter);
        }
        
        protected async Task<List<TDocument>> Many(FilterDefinition<TDocument> filter, bool isArchived = false)
        {
            filter &= F.Eq(x => x.IsArchived, isArchived);

            return await ExecuteOperation(async x => await (await Collection.FindAsync(filter)).ToListAsync(), filter);
        }
        
        protected async Task<long> Count(FilterDefinition<TDocument> filter, bool isArchived = false)
        {
            filter &= F.Eq(x => x.IsArchived, isArchived);

            return await ExecuteOperation(async x =>await Collection.CountDocumentsAsync(filter), filter);
        }
    }
}