using System.Threading.Tasks;
using MfPulse.Api.Attributes;
using MfPulse.Assessment.Contract.Criterions.Models.Requests;
using MfPulse.Assessment.Contract.Criterions.Models.Responses;
using MfPulse.Assessment.Contract.Criterions.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfPulse.Api.Controllers
{
    [Route("api/v1/criterion")]
    [ApiController]
    [ForAdmins]
    public class CriterionController
    {
        private readonly ICriterionService _criterionService;

        public CriterionController(ICriterionService criterionService)
        {
            _criterionService = criterionService;
        }

        [HttpPost]
        public async Task<CriterionResponse> Create([FromBody] CreateCriterionRequest request)
            => await _criterionService.Create(request);

        [HttpPut("{id}")]
        public async Task<CriterionResponse> Update(string id, [FromBody] UpdateCriterionRequest request)
            => await _criterionService.Update(id, request);

        [HttpGet("all")]
        public async Task<AllCriterionsResponse> All()
            => await _criterionService.All();

        [HttpGet("by-group/{groupId}")]
        public async Task<AllCriterionsResponse> ByGroup(string groupId)
            => await _criterionService.ByGroup(groupId);

        [HttpGet("{id}")]
        public async Task<CriterionResponse> Get(string id)
            => await _criterionService.Get(id);

        [HttpDelete("{id}")]
        public async Task Delete(string id)
            => await _criterionService.Delete(id);
    }
}