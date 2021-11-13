using System.Collections.Generic;

namespace MfPulse.Assessment.Contract.Questions.Models.Requests
{
    public record UpdateQuestionTextRequest
    {
        public string Id { get; set; }
        public string Text { get; set; }

    }
}