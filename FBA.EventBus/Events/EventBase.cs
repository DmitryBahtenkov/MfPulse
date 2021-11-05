using System;

namespace FBA.EventBus.Events
{
    public abstract class EventBase
    {
        public IServiceProvider ServiceProvider { get; }
        public string EventId { get; }

        protected EventBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            EventId = Guid.NewGuid().ToString();
        }
        
        
    }
}