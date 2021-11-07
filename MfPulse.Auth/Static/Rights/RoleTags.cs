using System.Linq;

namespace MfPulse.Auth.Static.Rights
{
    public static class RoleTags
    {
        public const string Super = nameof(Super);
        public const string Admin = nameof(Admin);
        public const string Default = nameof(Default);
        
        public static string[] GetAll()
        {
            return typeof(RoleTags)
                .GetFields()
                .Select(x => x.Name)
                .ToArray();
        }
    }
}