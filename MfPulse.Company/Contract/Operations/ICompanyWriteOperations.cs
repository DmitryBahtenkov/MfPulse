using System.Threading.Tasks;
using MfPulse.Company.Contract.Models;
using MfPulse.Mongo.Operations.Abstractions;

namespace MfPulse.Company.Contract.Operations
{
    public interface ICompanyWriteOperations : IWriteOperations<CompanyDocument>
    {
        public Task<CompanyDocument> UpdateName(string id, string name);
    }
}