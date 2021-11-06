using System.Threading.Tasks;
using MfPulse.Auth.Contract.Users.Database.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Auth.Contract.Users.Database.Operations
{
    public interface IUserWriteOperations : IWriteOperations<UserDocument>
    {
        public Task<UserDocument> UpdateToken(string id, string newToken);
        public Task<UserDocument> ClearToken(string id);
        public Task<UserDocument> UpdateInfo(string id, string lastName, string firstName, string middleName);
        public Task<UserDocument> UpdatePassword(string id, Password newPassword);
    }
}