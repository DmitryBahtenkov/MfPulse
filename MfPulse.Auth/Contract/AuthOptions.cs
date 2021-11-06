using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MfPulse.Auth.Contract
{
    public static class AuthOptions
    {
        public const string Issuer = "MfPulse"; // издатель токена
        public const string Audience = "User"; // потребитель токена
        const string Key = "qwertyuiopasdfghjkl";   // ключ для шифрации
        public const int Lifetime = 24 * 60; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}