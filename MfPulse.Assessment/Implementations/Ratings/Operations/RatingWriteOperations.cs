using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Ratings.Models;
using MfPulse.Assessment.Contract.Ratings.Operations;
using MfPulse.Mongo.Extensions;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Assessment.Implementations.Ratings.Operations
{
    public class RatingWriteOperations : WriteOperations<RatingDocument>, IRatingWriteOperations
    {
        public RatingWriteOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<RatingDocument> AddAssessment(string id, AssessmentEmbeddedDocument document)
        {
            return await UpdateOne(F.ById(id), U.Push(x => x.Assessments, document));
        }

        public async Task<RatingDocument> AddAssessments(string id, params AssessmentEmbeddedDocument[] documents)
        {
            return await UpdateOne(F.ById(id), U.PushEach(x => x.Assessments, documents));

        }
    }
}