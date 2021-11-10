using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Criterions.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Criterions.Operations
{
    public interface ICriterionWriteOperations : IWriteOperations<CriterionDocument>
    {
        public Task<CriterionDocument> UpdateName(string id, string name);
    }
}