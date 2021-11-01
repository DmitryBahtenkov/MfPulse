namespace MfPulse.Mongo.Document
{
    public interface IDocumentWithUserId : IDocumentWithCompanyId
    {
        public string UserId { get; set; }
    }
}