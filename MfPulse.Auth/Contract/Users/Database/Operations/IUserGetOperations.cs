using System.Threading.Tasks;
using MfPulse.Auth.Contract.Users.Database.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Auth.Contract.Users.Database.Operations
{
    public interface IUserGetOperations : IGetOperations<UserDocument>
    {
        public Task<UserDocument> ByToken(string token);
        public Task<UserDocument> ByLogin(string login);
        public Task<bool> CheckDuplicate(string login);
    }
}