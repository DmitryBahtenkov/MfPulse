using System.Threading.Tasks;
using MfPulse.EventBus.Events;
using MfPulse.Mongo.Document;

namespace MfPulse.EventBus
{
    public class EventInvoker<TDocument> where TDocument : IDocument
    {
        private readonly EventStorage<TDocument> _eventStorage;

        public EventInvoker(EventStorage<TDocument> eventStorage)
        {
            _eventStorage = eventStorage;
        }

        public async Task OnDocumentCreated(DocumentCreatedEvent<TDocument> eventArgs)
        {
            await _eventStorage.OnDocumentCreatedEvent(eventArgs);
        }

        public async Task OnDocumentDeleted(DocumentDeletedEvent<TDocument> eventArgs)
        {
            await _eventStorage.OnDocumentDeletedEvent(eventArgs);
        }
    }
}