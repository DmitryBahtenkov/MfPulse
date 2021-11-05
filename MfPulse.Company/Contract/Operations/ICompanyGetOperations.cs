using MfPulse.Company.Contract.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Company.Contract.Operations
{
    public interface ICompanyGetOperations : IGetOperations<CompanyDocument>
    { }
}