using MfPulse.Auth.Contract.Users.Database.Models;
using MfPulse.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace MfPulse.Assessment.Implementations.Ratings.Events
{
    public class UserRatingsEventBuilder : IEventBuilder
    {
        private readonly EventStorage<UserDocument> _eventStorage;

        public UserRatingsEventBuilder(EventStorage<UserDocument> eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public void BuildEvents()
        {
            _eventStorage.DocumentCreatedEvent += async @event =>
                await @event.ServiceProvider
                    .GetService<CreatedUserEventHandler>()
                    .OnCreate(@event);
        }
    }
}