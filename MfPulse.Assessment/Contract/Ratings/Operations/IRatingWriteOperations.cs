using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Ratings.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Ratings.Operations
{
    public interface IRatingWriteOperations : IWriteOperations<RatingDocument>
    {
        public Task<RatingDocument> AddAssessment(string id, AssessmentEmbeddedDocument document);
        public Task<RatingDocument> AddAssessments(string id, params AssessmentEmbeddedDocument[] documents);
    }
}