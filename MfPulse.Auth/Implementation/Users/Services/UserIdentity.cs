using MfPulse.Auth.Contract.Users.Services;
using MfPulse.Auth.Static.Extensions;
using MfPulse.Auth.Static.Rights;
using Microsoft.AspNetCore.Http;

namespace MfPulse.Auth.Implementation.Users.Services
{
    public class UserIdentity : IUserIdentity
    {
        public string UserId => _httpContextAccessor.HttpContext?.User?.GetClaim(Claims.UserId);
        public string CompanyId => _httpContextAccessor.HttpContext?.User?.GetClaim(Claims.Company);

        

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentity(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GroupId => _httpContextAccessor.HttpContext?.User?.GetClaim(Claims.Group);
    }
}