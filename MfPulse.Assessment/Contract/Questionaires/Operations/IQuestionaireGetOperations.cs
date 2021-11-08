using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questionaires.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Questionaires.Operations
{
    public interface IQuestionaireGetOperations : IGetOperations<QuestionaireDocument>
    {
        public Task<QuestionaireDocument> ByGroup(string groupId);
    }
}