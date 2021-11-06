using System.Threading.Tasks;
using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;
using MongoDB.Driver;

namespace MfPulse.Auth.Implementation.Groups.Operations
{
    public class GroupWriteOperations : WriteOperations<GroupDocument>, IGroupWriteOperations
    {
        public GroupWriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<GroupDocument> UpdateInfo(string id, string name, string responsibleId)
        {
            return await UpdateOne(F.ById(id),
                U
                    .Set(x => x.Name, name)
                    .Set(x => x.ResponsibleId, responsibleId));
        }
    }
}