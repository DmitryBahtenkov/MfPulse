using System;
using MfPulse.Mongo.Document;

namespace MfPulse.Auth.Contract.Database.Models
{
    public record UserDocument : IDocumentWithCompanyId
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public Password Password { get; set; }
        public bool IsNew { get; set; }
        public string CurrentToken { get; set; }
        public string RoleId { get; set; }
        public string CompanyId { get; set; }
        public string GroupId { get; set; }
    }
}