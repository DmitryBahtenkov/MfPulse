using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questionaires.Models.Requests;
using MfPulse.Assessment.Contract.Questionaires.Models.Responses;

namespace MfPulse.Assessment.Contract.Questionaires.Services
{
    public interface IQuestionaireService
    {
        public Task<QuestionaireResponse> Create(CreateQuestionaireRequest request);
        public Task<QuestionaireResponse> Update(string id, UpdateQuestionaireRequest request);
        public Task<AllQuestionairesResponse> All();
        public Task Delete(string id);
        public Task<QuestionaireResponse> Get(string id);
        public Task<QuestionaireResponse> ByGroup(string groupId);
    }
}