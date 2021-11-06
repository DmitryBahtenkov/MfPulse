using System.Threading.Tasks;
using MfPulse.Api.Attributes;
using MfPulse.Auth.Contract.Companies.Models.Requests;
using MfPulse.Auth.Contract.Companies.Models.Responses;
using MfPulse.Auth.Contract.Companies.Services;
using MfPulse.Auth.Static.Rights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MfPulse.Api.Controllers
{
    [Route("api/v1/company")]
    [ApiController]
    [ForAdmins]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<CompanyResponse> Create([FromBody] ChangeCompanyRequest request)
            => await _companyService.Create(request);
        
        [HttpPut("{id}")]
        public async Task<CompanyResponse> Update(string id, [FromBody] ChangeCompanyRequest request)
            => await _companyService.Update(id, request);

        [HttpGet("all")]
        [Authorize(Roles = RoleTags.Super)]
        public async Task<AllCompaniesResponse> All()
            => await _companyService.All();

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleTags.Super)]
        public async Task Delete(string id)
            => await _companyService.Delete(id);
    }
}