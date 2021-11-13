using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questionaires.Models.Requests;
using MfPulse.Assessment.Contract.Questionaires.Models.Responses;
using MfPulse.Assessment.Contract.Questionaires.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfPulse.Api.Controllers
{
    [Route("api/v1/questionaire")]
    [ApiController]
    public class QuestionaireController : ControllerBase
    {
        private readonly IQuestionaireService _questionaireService;

        public QuestionaireController(IQuestionaireService questionaireService)
        {
            _questionaireService = questionaireService;
        }

        [HttpPost]
        public async Task<QuestionaireResponse> Create(CreateQuestionaireRequest request)
            => await _questionaireService.Create(request);

        [HttpPut("{id}")]
        public async Task<QuestionaireResponse> Update(string id, UpdateQuestionaireRequest request)
            => await _questionaireService.Update(id, request);

        [HttpGet("all")]
        public async Task<AllQuestionairesResponse> All()
            => await _questionaireService.All();

        [HttpGet("by-group/{groupId}")]
        public async Task<AllQuestionairesResponse> ByGroup(string groupId)
            => await _questionaireService.ByGroup(groupId);

        [HttpDelete("{id}")]
        public async Task Delete(string id)
            => await _questionaireService.Delete(id);
    }
}