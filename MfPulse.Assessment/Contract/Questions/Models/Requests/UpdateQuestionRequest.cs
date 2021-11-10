using System.Collections.Generic;

namespace MfPulse.Assessment.Contract.Questions.Models.Requests
{
    public record UpdateQuestionRequest
    {
        public string Id { get; set; }
        public string QuestionaireId { get; set; }
        public string Text { get; set; }
        public List<ScoreEmbeddedDocument> YesScores { get; set; }
    }
}