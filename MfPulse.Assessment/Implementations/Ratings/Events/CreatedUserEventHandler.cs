using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Ratings.Services;
using MfPulse.Auth.Contract.Users.Database.Models;
using MfPulse.EventBus.Events;

namespace MfPulse.Assessment.Implementations.Ratings.Events
{
    public class CreatedUserEventHandler
    {
        private readonly IRatingService _ratingService;

        public CreatedUserEventHandler(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public async Task OnCreate(DocumentCreatedEvent<UserDocument> @event)
        {
            var newDocument = @event.NewDocument;

            await _ratingService.CreateDefault(newDocument.Id);
        }
    }
}