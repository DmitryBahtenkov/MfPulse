using System;
using MfPulse.Mongo.Document;
using MongoDB.Bson.Serialization.Attributes;

namespace MfPulse.Auth.Contract.Users.Database.Models
{
    public record RoleDocument : IDocument
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }

        [BsonIgnore] public string[] Claims { get; set; } = Array.Empty<string>();
    }
}