using System.Collections.Generic;

namespace MfPulse.Auth.Contract.Companies.Models.Responses
{
    public record AllCompaniesResponse
    {
        public List<CompanyResponse> Companies { get; set; }
    }
}