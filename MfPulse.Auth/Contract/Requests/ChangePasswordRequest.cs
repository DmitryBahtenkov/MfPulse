using MfPulse.Auth.Contract.Database.Models;

namespace MfPulse.Auth.Contract.Requests
{
    public record ChangePasswordRequest()
    {
        public string Id { get; set; }
        public Password Password { get; set; }
    }
}