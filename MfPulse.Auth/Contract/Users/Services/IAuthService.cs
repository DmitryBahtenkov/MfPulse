using System.Threading.Tasks;
using MfPulse.Auth.Contract.Users.Requests;
using MfPulse.Auth.Contract.Users.Responses;

namespace MfPulse.Auth.Contract.Users.Services
{
    public interface IAuthService
    {
        public Task<UserResponse> Login(LoginRequest request);
        public Task Logout(string userId);
    }
}