using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Criterions.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Criterions.Operations
{
    public interface ICriterionGetOperations : IGetOperations<CriterionDocument>
    {
        public Task<List<CriterionDocument>> ByGroup(string groupId);
    }
}