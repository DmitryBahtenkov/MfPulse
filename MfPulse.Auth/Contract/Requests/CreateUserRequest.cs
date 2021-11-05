using System;
using MfPulse.Auth.Contract.Database.Models;

namespace MfPulse.Auth.Contract.Requests
{
    public record CreateUserRequest()
    {
        public string Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public Password Password { get; set; }
        public string RoleId { get; set; }
    }
}