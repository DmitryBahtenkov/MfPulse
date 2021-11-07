using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Criterions.Models;
using MfPulse.Assessment.Contract.Criterions.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Assessment.Implementations.Criterions.Operations
{
    public class CriterionWriteOperations : WriteOperations<CriterionDocument>, ICriterionWriteOperations
    {
        public CriterionWriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<CriterionDocument> UpdateName(string id, string name)
        {
            return await UpdateOne(F.ById(id), U.Set(x => x.Name, name));
        }
    }
}