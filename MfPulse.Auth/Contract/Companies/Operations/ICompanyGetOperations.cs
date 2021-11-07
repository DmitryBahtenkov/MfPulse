using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Auth.Contract.Companies.Operations
{
    public interface ICompanyGetOperations : IGetOperations<CompanyDocument>
    { }
}