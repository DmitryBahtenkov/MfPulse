using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questionaires.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Questionaires.Operations
{
    public interface IQuestionaireWriteOperations : IWriteOperations<QuestionaireDocument>
    {
        public Task<QuestionaireDocument> UpdateInfo(string id, string name, string companyId, string groupId);
    }
}