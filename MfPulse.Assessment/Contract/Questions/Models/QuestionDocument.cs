using System;
using System.Collections.Generic;
using MfPulse.Mongo.Document;

namespace MfPulse.Assessment.Contract.Questions.Models
{
    public record QuestionDocument : IDocument
    {
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string QuestionaireId { get; set; }
        public string Text { get; set; }
        public List<ScoreEmbeddedDocument> YesScores { get; set; }
    }

    public record ScoreEmbeddedDocument
    {
        public string CriterionId { get; set; }
        public int Score { get; set; }
    }
}