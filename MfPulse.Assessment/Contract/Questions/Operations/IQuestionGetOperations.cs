using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questions.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Questions.Operations
{
    public interface IQuestionGetOperations : IGetOperations<QuestionDocument>
    {
        public Task<List<QuestionDocument>> ByQuestionaire(string questionaireId);
    }
}