using System;

namespace MfPulse.Mongo.Document
{
    public interface IDocument
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}