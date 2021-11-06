using MfPulse.Auth.Contract.Database.Models;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Auth.Contract.Rights;
using MfPulse.Auth.Contract.Services;
using MfPulse.Auth.Implementation.Extensions;
using Microsoft.AspNetCore.Http;

namespace MfPulse.Auth.Implementation.Services
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