using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Criterions.Models.Requests;
using MfPulse.Assessment.Contract.Criterions.Models.Responses;

namespace MfPulse.Assessment.Contract.Criterions.Services
{
    public interface ICriterionService
    {
        public Task<CriterionResponse> Create(CreateCriterionRequest request);
        public Task<CriterionResponse> Update(string id, UpdateCriterionRequest request);
        public Task<CriterionResponse> Get(string id);
        public Task<AllCriterionsResponse> ByGroup(string groupId);
        public Task<AllCriterionsResponse> All();
        public Task Delete(string id);
    }
}