using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Auth.Implementation.Groups.Operations
{
    public class GroupGetOperations : GetOperations<GroupDocument>, IGroupGetOperations
    {
        public GroupGetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }
    }
}