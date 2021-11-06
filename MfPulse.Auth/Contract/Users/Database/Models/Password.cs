namespace MfPulse.Auth.Contract.Users.Database.Models
{
    public record Password
    {
        public string Hash { get; set; }
        public string Salt { get; set; }

        public Password(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }
        
        public Password(){}
    }
}