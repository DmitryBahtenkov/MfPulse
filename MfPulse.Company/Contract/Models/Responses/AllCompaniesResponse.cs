using System.Collections.Generic;

namespace MfPulse.Company.Contract.Models.Responses
{
    public record AllCompaniesResponse
    {
        public List<CompanyResponse> Companies { get; set; }
    }
}