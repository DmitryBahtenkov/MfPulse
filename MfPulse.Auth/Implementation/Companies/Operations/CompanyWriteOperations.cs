using System.Threading.Tasks;
using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.Auth.Contract.Companies.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Auth.Implementation.Companies.Operations
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