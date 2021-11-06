using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MfPulse.Auth.Static
{
    public static class AuthOptions
    {
        public const string Issuer = "MfPulse"; // издатель токена
        public const string Audience = "User"; // потребитель токена
        const string Key = "qwertyuiopasdfghjkl";   // ключ для шифрования
        public const int Lifetime = 24 * 60; // время жизни токена в минутах
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}