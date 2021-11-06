using System.Threading.Tasks;
using MfPulse.Auth.Contract.Users.Requests;
using MfPulse.Auth.Contract.Users.Responses;

namespace MfPulse.Auth.Contract.Users.Services
{
    public interface IUserService
    {
        public Task<UserResponse> Create(CreateUserRequest request);
        public Task<UserResponse> Update(string id, UpdateUserRequest request);
    }
}