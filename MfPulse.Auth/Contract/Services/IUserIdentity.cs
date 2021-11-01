using System.Security.Principal;
using MfPulse.Auth.Contract.Database;
using MfPulse.Auth.Contract.Database.Models;

namespace MfPulse.Auth.Contract.Services
{
    public interface IUserIdentity : IIdentity
    {
        public UserDocument User { get; }
    }
}