namespace MfPulse.Mongo.Document
{
    public interface IDocumentWithCompanyId : IDocument
    {
        public string CompanyId { get; set; }
    }
}