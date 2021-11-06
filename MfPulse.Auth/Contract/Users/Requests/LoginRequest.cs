namespace MfPulse.Auth.Contract.Users.Requests
{
    public record LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}