using System.Net.Sockets;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Ratings.Models;
using MfPulse.Assessment.Contract.Ratings.Operations;
using MfPulse.Assessment.Contract.Ratings.Services;
using MfPulse.Auth.Contract.Users.Services;
using MfPulse.CrossCutting.Exceptions;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Assessment.Implementations.Ratings.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingGetOperations _ratingGetOperations;
        private readonly IRatingWriteOperations _ratingWriteOperations;
        private readonly IUserIdentity _userIdentity;

        public RatingService(IRatingGetOperations ratingGetOperations, IRatingWriteOperations ratingWriteOperations,
            IUserIdentity userIdentity)
        {
            _ratingGetOperations = ratingGetOperations;
            _ratingWriteOperations = ratingWriteOperations;
            _userIdentity = userIdentity;
        }

        public async Task CreateDefault(string userId)
        {
            var rating = new RatingDocument
            {
                Id = IdGen.New,
                CompanyId = _userIdentity.CompanyId,
                TotalScore = 0,
                UserId = userId
            };

            await _ratingWriteOperations.Insert(rating);
        }

        public async Task Delete(string id)
        {
            var document = await _ratingGetOperations.ById(id);
            if (document is null)
            {
                throw new NotFoundException();
            }

            await _ratingWriteOperations.Delete(document);
        }

        public async Task AddAssessment(string userId, AssessmentEmbeddedDocument document)
        {
            var rating = await GetRating(userId);

            await _ratingWriteOperations.AddAssessment(rating.Id, document);
        }

        public async Task AddAssessments(string userId, params AssessmentEmbeddedDocument[] documents)
        {
            var rating = await GetRating(userId);

            await _ratingWriteOperations.AddAssessments(rating.Id, documents);
        }

        private async Task<RatingDocument> GetRating(string userId)
        {
            var rating = await _ratingGetOperations.ByUser(userId);
            if (rating is null)
            {
                throw new BusinessException("Не найден рейтинг");
            }

            return rating;
        }
    }
}