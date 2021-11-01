namespace MfPulse.Mongo.Security
{
    public interface IMongoIdentity
    {
        public string UserId { get; }
        public string CompanyId { get; }
    }
}