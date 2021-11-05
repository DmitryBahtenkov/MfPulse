using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBA.EventBus.Events;
using MfPulse.Mongo.Document;

namespace FBA.EventBus
{
    public class EventStorage<TDocument> where TDocument : IDocument
    {
        public event Func<DocumentCreatedEvent<TDocument>, Task> DocumentChangedEvent;
        public event Func<DocumentDeletedEvent<TDocument>, Task> DocumentDeletedEvent;

        internal virtual async Task OnDocumentChangedEvent(DocumentCreatedEvent<TDocument> arg)
        {
            if (DocumentChangedEvent is not null)
            {
                await DocumentChangedEvent.Invoke(arg);
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
                .Where(x=>x.Assembly?.FullName?.Contains("Testing") == true)
                .Where(x => x.IsClass && typeof(IEventBuilder).IsAssignableFrom(x));

            return types.Select(x=> (IEventBuilder)Activator.CreateInstance(x, serviceProvider.GetService(typeof(EventStorage<TDocument>))));
        }
    }
}