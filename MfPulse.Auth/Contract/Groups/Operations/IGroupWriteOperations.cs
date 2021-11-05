using System.Threading.Tasks;
using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Auth.Contract.Groups.Operations
{
    public interface IGroupWriteOperations : IWriteOperations<GroupDocument>
    {
        public Task<GroupDocument> UpdateInfo(string id, string name, string responsibleId);
    }
}