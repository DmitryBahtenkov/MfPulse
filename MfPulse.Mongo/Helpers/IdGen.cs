using MongoDB.Bson;

namespace MfPulse.Mongo.Helpers
{
    public static class IdGen
    {
        public static string New => ObjectId.GenerateNewId().ToString();
    }
}