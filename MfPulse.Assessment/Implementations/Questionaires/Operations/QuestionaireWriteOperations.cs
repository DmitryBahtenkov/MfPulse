using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Questionaires.Models;
using MfPulse.Assessment.Contract.Questionaires.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;
using MongoDB.Driver;

namespace MfPulse.Assessment.Implementations.Questionaires.Operations
{
    public class QuestionaireWriteOperations : WriteOperations<QuestionaireDocument>, IQuestionaireWriteOperations
    {
        public QuestionaireWriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<QuestionaireDocument> UpdateInfo(string id, string name, string groupId)
        {
            return await UpdateOne(F.ById(id), 
                U.Set(x => x.Name, name)
                    .Set(x => x.GroupId, groupId));
        }
    }
}