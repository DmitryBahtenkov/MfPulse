using MfPulse.Auth.Contract.Database.Models;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Auth.Contract.Services;
using Microsoft.AspNetCore.Http;

namespace MfPulse.Auth.Implementation.Services
{
    public class UserIdentity : IUserIdentity
    {
        public string UserId => User?.Id;
        public string CompanyId => User?.CompanyId;

        public UserDocument User => _userGetOperations
            .ByLogin(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
            .ConfigureAwait(false).GetAwaiter().GetResult();

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserGetOperations _userGetOperations;

        public UserIdentity(IHttpContextAccessor httpContextAccessor, IUserGetOperations userGetOperations)
        {
            _httpContextAccessor = httpContextAccessor;
            _userGetOperations = userGetOperations;
        }
    }
}