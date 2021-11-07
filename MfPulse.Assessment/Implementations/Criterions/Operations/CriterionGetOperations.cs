using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Criterions.Models;
using MfPulse.Assessment.Contract.Criterions.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Assessment.Implementations.Criterions.Operations
{
    public class CriterionGetOperations : GetOperations<CriterionDocument>, ICriterionGetOperations
    {
        public CriterionGetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<List<CriterionDocument>> ByGroup(string groupId)
        {
            return await Many(F.Eq(x => x.GroupId, groupId));
        }
    }
}