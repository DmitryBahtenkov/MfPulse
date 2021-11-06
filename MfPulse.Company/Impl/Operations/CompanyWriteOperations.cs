using System.Threading.Tasks;
using MfPulse.Company.Contract.Models;
using MfPulse.Company.Contract.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Company.Impl.Operations
{
    public class CompanyWriteOperations : WriteOperations<CompanyDocument>, ICompanyWriteOperations
    {
        public CompanyWriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<CompanyDocument> UpdateName(string id, string name)
        {
            return await UpdateOne(F.ById(id), U.Set(x => x.Name, name));
        }
    }
}