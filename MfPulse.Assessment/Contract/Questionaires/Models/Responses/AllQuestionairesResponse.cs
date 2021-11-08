using System.Collections.Generic;

namespace MfPulse.Assessment.Contract.Questionaires.Models.Responses
{
    public record AllQuestionairesResponse
    {
        public List<QuestionaireResponse> Questionaires { get; set; }
    }
}