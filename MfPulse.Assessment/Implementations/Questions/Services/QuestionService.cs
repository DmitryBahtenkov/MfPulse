using System.Linq;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Criterions.Operations;
using MfPulse.Assessment.Contract.Questionaires.Operations;
using MfPulse.Assessment.Contract.Questions.Models;
using MfPulse.Assessment.Contract.Questions.Models.Requests;
using MfPulse.Assessment.Contract.Questions.Models.Responses;
using MfPulse.Assessment.Contract.Questions.Models.Services;
using MfPulse.Assessment.Contract.Questions.Operations;
using MfPulse.CrossCutting.Exceptions;
using MfPulse.CrossCutting.Extensions;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Assessment.Implementations.Questions.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionGetOperations _questionGetOperations;
        private readonly IQuestionWriteOperations _questionWriteOperations;
        private readonly IQuestionaireGetOperations _questionaireGetOperations;
        private readonly ICriterionGetOperations _criterionGetOperations;

        public QuestionService(IQuestionGetOperations questionGetOperations, 
            IQuestionWriteOperations questionWriteOperations,
            IQuestionaireGetOperations questionaireGetOperations, 
            ICriterionGetOperations criterionGetOperations)
        {
            _questionGetOperations = questionGetOperations;
            _questionWriteOperations = questionWriteOperations;
            _questionaireGetOperations = questionaireGetOperations;
            _criterionGetOperations = criterionGetOperations;
        }

        public async Task<QuestionResponse> Create(CreateQuestionRequest request)
        {
            if (!await _questionaireGetOperations.ExistById(request.QuestionaireId))
            {
                throw new BusinessException("Не найден опрос");
            }

            var newDoc = new QuestionDocument
            {
                Id = IdGen.New,
                QuestionaireId = request.QuestionaireId,
                Text = request.Text
            };

            newDoc = await _questionWriteOperations.Insert(newDoc);

            return await Map(newDoc);
        }

        public async Task<QuestionResponse> Update(UpdateQuestionTextRequest textRequest)
        {
            var document = await _questionWriteOperations.UpdateText(textRequest.Id, textRequest.Text);
            if (document is null)
            {
                throw new BusinessException("Не найден вопрос");
            }

            return await Map(document);
        }

        public async Task<ManyQuestionsResponse> ByQuestionaire(string questionaireId)
        {
            var docs = await _questionGetOperations.ByQuestionaire(questionaireId);

            return new ManyQuestionsResponse
            {
                Questions = await docs.Select(Map).ToListAsync()
            };
        }

        public async Task<QuestionResponse> Get(string id)
        {
            var document = await _questionGetOperations.ById(id);

            if (document is null)
            {
                throw new NotFoundException();
            }

            return await Map(document);
        }

        public async Task Delete(string id)
        {
            var document = await _questionGetOperations.ById(id);

            if (document is not null)
            {
                await _questionWriteOperations.Delete(document);
            }
        }

        private async Task<QuestionResponse> Map(QuestionDocument document)
        {
            var questionaire = await _questionaireGetOperations.ById(document.QuestionaireId);
            
            var response = new QuestionResponse
            {
                Id = document.Id,
                Text = document.Text,
                QuestionaireName = questionaire.Name,
                QuestionaireId = questionaire.Id,
                Scores = await document.YesScores.Select(async x => new ScoreResponse
                {
                    CriterionId = x.CriterionId,
                    Score = x.Score,
                    CriterionName = (await _criterionGetOperations.ById(x.CriterionId))?.Name
                }).ToListAsync()
            };

            return response;
        }
    }
}