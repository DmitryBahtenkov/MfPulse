using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.Auth.Contract.Companies.Operations;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Auth.Implementation.Companies.Operations
{
    public class CompanyGetOperations : GetOperations<CompanyDocument>, ICompanyGetOperations
    {
        public CompanyGetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }
    }
}