using MfPulse.Auth.Static.Rights;
using Microsoft.AspNetCore.Authorization;

namespace MfPulse.Api.Attributes
{
    public class ForAllAttribute : AuthorizeAttribute
    {
        public ForAllAttribute()
        {
            Roles = $"{RoleTags.Admin},{RoleTags.Super},{RoleTags.Default}";
        }
    }
}