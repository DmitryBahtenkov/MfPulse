using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Ratings.Models;

namespace MfPulse.Assessment.Contract.Ratings.Services
{
    public interface IRatingService
    {
        public Task CreateDefault(string userId);
        public Task Delete(string id);
        public Task AddAssessment(string userId, AssessmentEmbeddedDocument document);
        public Task AddAssessments(string userId, params AssessmentEmbeddedDocument[] documents);
    }
}