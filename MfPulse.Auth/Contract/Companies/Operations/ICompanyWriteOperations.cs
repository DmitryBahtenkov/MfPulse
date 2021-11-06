using System.Threading.Tasks;
using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Auth.Contract.Companies.Operations
{
    public interface ICompanyWriteOperations : IWriteOperations<CompanyDocument>
    {
        public Task<CompanyDocument> UpdateName(string id, string name);
    }
}