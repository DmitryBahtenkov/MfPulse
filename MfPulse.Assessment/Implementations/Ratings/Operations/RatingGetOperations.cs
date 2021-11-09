using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Ratings.Models;
using MfPulse.Assessment.Contract.Ratings.Operations;
using MfPulse.Mongo.Operations;
using MfPulse.Mongo.Operations.Implementations;
using MfPulse.Mongo.Security;

namespace MfPulse.Assessment.Implementations.Ratings.Operations
{
    public class RatingGetOperations : GetOperations<RatingDocument>, IRatingGetOperations
    {
        public RatingGetOperations(DbContext dbContext, MongoSecurityFilter mongoSecurityFilter) : base(dbContext, mongoSecurityFilter)
        {
        }

        public async Task<RatingDocument> ByUser(string userId)
        {
            return await One(F.Eq(x => x.UserId, userId));
        }
    }
}