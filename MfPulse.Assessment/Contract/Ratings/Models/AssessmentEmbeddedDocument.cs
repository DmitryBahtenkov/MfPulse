using System;

namespace MfPulse.Assessment.Contract.Ratings.Models
{
    public record AssessmentEmbeddedDocument
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string CriterionId { get; set; }
        public string Score { get; set; }
    }
}