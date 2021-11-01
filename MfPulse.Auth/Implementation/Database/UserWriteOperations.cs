using System.Threading.Tasks;
using MfPulse.Auth.Contract.Database.Models;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;
using MongoDB.Driver;

namespace MfPulse.Auth.Implementation.Database
{
    public class UserWriteOperations : WriteOperations<UserDocument>, IUserWriteOperations
    {
        public UserWriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }
        
        public async Task<UserDocument> UpdateToken(string id, string newToken)
        {
            return await UpdateOne(GetIdFilter(id), U.Set(x => x.CurrentToken, newToken));
        }

        public async Task<UserDocument> ClearToken(string id)
        {
            return await UpdateOne(GetIdFilter(id), U.Set(x => x.CurrentToken, null));
        }

        public async Task<UserDocument> UpdateInfo(string id, string lastName, string firstName, string middleName)
        {
            var update = U
                .Set(x => x.LastName, lastName)
                .Set(x=>x.FirstName, firstName)
                .Set(x=>x.MiddleName, middleName);

            return await UpdateOne(GetIdFilter(id), update);
        }

        public async Task<UserDocument> UpdatePassword(string id, Password newPassword)
        {
            return await UpdateOne(GetIdFilter(id), U.Set(x => x.Password, newPassword));
        }
    }
}