using System;
using System.Security.Cryptography;
using System.Text;
using MfPulse.Auth.Contract.Users.Database.Models;

namespace MfPulse.Auth.Static
{
    public class PasswordHelper
    {
        public static Password GeneratePassword(string password)
        {
            var rnd = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rnd.GetBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var md = MD5.Create();
            var saltedPass = password + salt;
            var hash = Convert.ToBase64String(md.ComputeHash(Encoding.Unicode.GetBytes(saltedPass)));
            return new Password
            {
                Hash = hash,
                Salt = salt
            };
        }

        public static bool ComparePassword(UserDocument userDocument, string password)
        {
            var md = MD5.Create();
            var saltedPass = password + userDocument.Password?.Salt;
            var hash = Convert.ToBase64String(md.ComputeHash(Encoding.Unicode.GetBytes(saltedPass)));

            return hash == userDocument.Password?.Hash;
        }
    }
}