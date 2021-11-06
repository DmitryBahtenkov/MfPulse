using MfPulse.Company.Contract.Models;
using MfPulse.Company.Contract.Operations;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Company.Impl.Operations
{
    public class CompanyGetOperations : GetOperations<CompanyDocument>, ICompanyGetOperations
    {
        public CompanyGetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }
    }
}