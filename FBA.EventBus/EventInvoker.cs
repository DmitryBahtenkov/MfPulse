using System.Threading.Tasks;
using FBA.EventBus.Events;
using MfPulse.Mongo.Document;

namespace FBA.EventBus
{
    public class EventInvoker<TDocument> where TDocument : IDocument
    {
        private readonly EventStorage<TDocument> _eventStorage;

        public EventInvoker(EventStorage<TDocument> eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public async Task OnDocumentChanged(DocumentCreatedEvent<TDocument> eventArgs)
        {
            await _eventStorage.OnDocumentChangedEvent(eventArgs);
        }

        public async Task OnDocumentDeleted(DocumentDeletedEvent<TDocument> eventArgs)
        {
            await _eventStorage.OnDocumentDeletedEvent(eventArgs);
        }
    }
}