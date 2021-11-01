using MfPulse.Auth.Contract.Database;
using MfPulse.Auth.Contract.Database.Models;

namespace MfPulse.Auth.Contract.Services
{
    public interface IUserIdentity
    {
        public UserDocument User { get; }
    }
}