using System.Threading.Tasks;
using MfPulse.Auth.Contract.Requests;
using MfPulse.Auth.Contract.Responses;

namespace MfPulse.Auth.Contract.Services
{
    public interface IUserService
    {
        public Task<UserResponse> Create(CreateUserRequest request);
        public Task<UserResponse> Update(string id, UpdateUserRequest request);
    }
}