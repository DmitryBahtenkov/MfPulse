using MfPulse.Auth.Static.Rights;
using Microsoft.AspNetCore.Authorization;

namespace MfPulse.Api.Attributes
{
    public class ForAdminsAttribute : AuthorizeAttribute
    {
        public ForAdminsAttribute()
        {
            Roles = $"{RoleTags.Admin},{RoleTags.Super}";
        }
    }
}