using System.Security.Principal;
using MfPulse.Auth.Contract.Database;
using MfPulse.Auth.Contract.Database.Models;
using MfPulse.Mongo.Security;

namespace MfPulse.Auth.Contract.Services
{
    public interface IUserIdentity : IMongoIdentity
    {
        public string GroupId { get; }
    }
}