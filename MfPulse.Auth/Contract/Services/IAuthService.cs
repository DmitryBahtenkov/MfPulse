using System.Threading.Tasks;
using MfPulse.Auth.Contract.Requests;
using MfPulse.Auth.Contract.Responses;

namespace MfPulse.Auth.Contract.Services
{
    public interface IAuthService
    {
        public Task<UserResponse> Login(LoginRequest request);
        public Task Logout(string userId);
    }
}