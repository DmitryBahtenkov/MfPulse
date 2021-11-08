using System;
using System.Collections.Generic;
using System.Linq;
using MfPulse.Mongo.Document;

namespace MfPulse.Assessment.Contract.Ratings.Models
{
    public record RatingDocument : IDocumentWithCompanyId
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public int TotalScore { get; set; }
        public List<AssessmentEmbeddedDocument> Assessments { get; set; } = new();
    }
}