using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questionaires.Models;
using MfPulse.Assessment.Contract.Questionaires.Operations;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Assessment.Implementations.Questionaires.Operations
{
    public class QuestionaireGetOperations : GetOperations<QuestionaireDocument>, IQuestionaireGetOperations
    {
        public QuestionaireGetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<List<QuestionaireDocument>> ByGroup(string groupId)
        {
            return await Many(F.Eq(x => x.GroupId, groupId));
        }
    }
}