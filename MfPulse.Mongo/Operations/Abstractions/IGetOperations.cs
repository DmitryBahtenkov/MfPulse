using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Mongo.Document;

namespace MfPulse.Mongo.Operations.Abstractions
{
    public interface IGetOperations<TDocument> where TDocument : IDocument
    {
        public Task<List<TDocument>> All(bool isArchived = false);
        public Task<TDocument> ById(string id);
        public Task<List<TDocument>> ByIds(params string[] ids);
        public Task<bool> ExistById(string id);
    }
}