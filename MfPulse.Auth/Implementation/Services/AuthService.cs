using System.Threading.Tasks;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Auth.Contract.Requests;
using MfPulse.Auth.Contract.Responses;
using MfPulse.Auth.Contract.Services;
using MfPulse.Auth.Implementation.Database;

namespace MfPulse.Auth.Implementation.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserWriteOperations _userWriteOperations;
        private readonly IUserGetOperations _userGetOperations;

        public AuthService(IUserWriteOperations userWriteOperations, IUserGetOperations userGetOperations)
        {
            _userWriteOperations = userWriteOperations;
            _userGetOperations = userGetOperations;
        }

        public async Task<UserResponse> Login(LoginRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task Logout(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}