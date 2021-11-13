using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questions.Models.Requests;
using MfPulse.Assessment.Contract.Questions.Models.Responses;

namespace MfPulse.Assessment.Contract.Questions.Models.Services
{
    public interface IQuestionService
    {
        public Task<QuestionResponse> Create(CreateQuestionRequest request);
        public Task<QuestionResponse> Update(UpdateQuestionTextRequest textRequest);
        public Task<ManyQuestionsResponse> ByQuestionaire(string questionaireId);
        public Task<QuestionResponse> Get(string id);
        public Task Delete(string id);
    }
}