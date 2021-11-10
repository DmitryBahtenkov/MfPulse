using System.Collections.Generic;
using System.Diagnostics;

namespace MfPulse.Assessment.Contract.Questions.Models.Responses
{
    public record QuestionResponse
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string QuestionaireId { get; set; }
        public string QuestionaireName { get; set; }
        public List<ScoreResponse> Scores { get; set; }
        
    }

    public record ScoreResponse
    {
        public string CriterionId { get; set; }
        public string CriterionName { get; set; }
        public int Score { get; set; }
    }
}