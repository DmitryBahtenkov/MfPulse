using System;
using MfPulse.Mongo.Document;

namespace MfPulse.EventBus.Events
{
    public class DocumentDeletedEvent<TDocument> : EventBase where TDocument : IDocument
    {
        public TDocument Document { get; }
        
        public DocumentDeletedEvent(IServiceProvider serviceProvider, TDocument document) : base(serviceProvider)
        {
            Document = document;
        }
    }
}