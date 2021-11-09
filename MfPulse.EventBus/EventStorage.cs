using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MfPulse.EventBus.Events;
using MfPulse.Mongo.Document;

namespace MfPulse.EventBus
{
    public class EventStorage<TDocument> where TDocument : IDocument
    {
        public event Func<DocumentCreatedEvent<TDocument>, Task> DocumentCreatedEvent;
        public event Func<DocumentDeletedEvent<TDocument>, Task> DocumentDeletedEvent;

        internal virtual async Task OnDocumentCreatedEvent(DocumentCreatedEvent<TDocument> arg)
        {
            if (DocumentCreatedEvent is not null)
            {
                await DocumentCreatedEvent.Invoke(arg);
            }
        }
        
        internal virtual async Task OnDocumentDeletedEvent(DocumentDeletedEvent<TDocument> arg)
        {
            if (DocumentDeletedEvent is not null)
            {
                await DocumentDeletedEvent.Invoke(arg);
            }
        }

        public static IEnumerable<IEventBuilder> GetEventBuilders(IServiceProvider serviceProvider)
        {
            var types = AppDomain.CurrentDomain.
                GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x=>x.Assembly?.FullName?.Contains("MfPulse") == true)
                .Where(x => x.IsClass && typeof(IEventBuilder).IsAssignableFrom(x));

            return types.Select(x=>
            {
                var constructor = x.GetConstructors().First();
                return (IEventBuilder) Activator.CreateInstance(x,
                        serviceProvider
                            .GetService(constructor.GetParameters().First().ParameterType));
            });
        }
    }
}