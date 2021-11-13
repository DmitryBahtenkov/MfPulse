using System.Collections.Generic;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questions.Models;
using MfPulse.Assessment.Contract.Questions.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Assessment.Implementations.Questions.Operations
{
    public class QuestionWriteOperations : WriteOperations<QuestionDocument>, IQuestionWriteOperations
    {
        public QuestionWriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<QuestionDocument> UpdateText(string id, string text)
        {
            return await UpdateOne(F.ById(id), U.Set(x => x.Text, text));
        }

        public async Task<QuestionDocument> SetYesScores(string id, List<ScoreEmbeddedDocument> score)
        {
            return await UpdateOne(F.ById(id), U.Set(x => x.YesScores, score));

        }
    }
}