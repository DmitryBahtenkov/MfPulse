using System;
using MfPulse.Mongo.Document;

namespace FBA.EventBus.Events
{
    public class DocumentCreatedEvent<TDocument> : EventBase where TDocument : IDocument
    {
        public TDocument NewDocument { get; }

        public DocumentCreatedEvent(IServiceProvider serviceProvider, TDocument newDocument) : base(serviceProvider)
        {
            NewDocument = newDocument;
        }
    }
}