using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questions.Models;
using MfPulse.Assessment.Contract.Questions.Operations;
using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Assessment.Implementations.Questions.Operations
{
    public class QuestionGetOperations : GetOperations<QuestionDocument>, IQuestionGetOperations
    {
        public QuestionGetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<List<QuestionDocument>> ByQuestionaire(string questionaireId)
        {
            return await Many(F.Eq(x => x.QuestionaireId, questionaireId));
        }
    }
}