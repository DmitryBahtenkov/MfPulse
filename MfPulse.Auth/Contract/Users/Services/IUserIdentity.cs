using MfPulse.Mongo.Security;

namespace MfPulse.Auth.Contract.Users.Services
{
    public interface IUserIdentity : IMongoIdentity
    {
        public string GroupId { get; }
    }
}