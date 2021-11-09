using System.Collections.Generic;

namespace MfPulse.Assessment.Contract.Criterions.Models.Responses
{
    public record AllCriterionsResponse
    {
        public List<CriterionResponse> Criterions { get; set; }
    }
}