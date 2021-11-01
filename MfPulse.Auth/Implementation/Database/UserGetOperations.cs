using System.Threading.Tasks;
using MfPulse.Auth.Contract.Database.Models;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;

namespace MfPulse.Auth.Implementation.Database
{
    public class UserGetOperations : GetOperations<UserDocument>, IUserGetOperations
    {
        public UserGetOperations(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserDocument> ByToken(string token)
        {
            return await One(F.Eq(x => x.CurrentToken, token));
        }

        public async Task<UserDocument> ByLogin(string login)
        {
            return await One(F.Eq(x => x.Login, login));

        }

        public async Task<bool> CheckDuplicate(string login)
        {
            return await Count(F.Eq(x => x.Login, login)) > 0;
        }
    }
}