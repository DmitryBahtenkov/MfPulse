using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace MfPulse.Auth.Implementation.Companies.Events
{
    public class CompanyEventBuilder : IEventBuilder
    {
        private readonly EventStorage<CompanyDocument> _eventStorage;

        public CompanyEventBuilder(EventStorage<CompanyDocument> eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public void BuildEvents()
        {
            _eventStorage.DocumentCreatedEvent += async @event
                => await @event.ServiceProvider
                    .GetService<CompanyCreatedEventHandler>()
                    .OnCompanyCreated(@event);
        }
    }
}