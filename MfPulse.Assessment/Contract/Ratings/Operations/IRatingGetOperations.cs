using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Ratings.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Assessment.Contract.Ratings.Operations
{
    public interface IRatingGetOperations : IGetOperations<RatingDocument>
    {
        public Task<RatingDocument> ByUser(string userId);
    }
}