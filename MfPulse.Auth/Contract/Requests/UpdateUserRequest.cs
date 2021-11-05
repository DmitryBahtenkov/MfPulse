using MfPulse.Auth.Contract.Database.Models;

namespace MfPulse.Auth.Contract.Requests
{
    public record UpdateUserRequest()
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
    }
}