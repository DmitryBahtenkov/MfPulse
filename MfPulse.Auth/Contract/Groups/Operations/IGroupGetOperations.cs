using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Auth.Contract.Groups.Operations
{
    public interface IGroupGetOperations : IGetOperations<GroupDocument>
    { }
}