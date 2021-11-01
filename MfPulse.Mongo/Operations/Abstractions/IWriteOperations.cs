using System.Threading.Tasks;
using MfPulse.Mongo.Document;

namespace MfPulse.Mongo.Operations.Abstractions
{
    public interface IWriteOperations<TDocument> where TDocument : IDocument
    {
        public Task<TDocument> Insert(TDocument document);
        public Task<TDocument> Delete(TDocument document);
        public Task<TDocument> SafeDelete(TDocument document);
        public Task<TDocument> Upsert(TDocument document);
    }
}