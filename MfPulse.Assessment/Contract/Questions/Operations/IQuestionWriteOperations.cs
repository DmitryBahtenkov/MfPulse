using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questions.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Questions.Operations
{
    public interface IQuestionWriteOperations : IWriteOperations<QuestionDocument>
    {
        public Task<QuestionDocument> UpdateText(string id, string text);
        public Task<QuestionDocument> SetYesScores(string id, List<ScoreEmbeddedDocument> score);
    }
}