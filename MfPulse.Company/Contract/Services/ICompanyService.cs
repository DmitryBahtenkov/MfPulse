using System.Threading.Tasks;
using MfPulse.Company.Contract.Models.Requests;
using MfPulse.Company.Contract.Models.Responses;

namespace MfPulse.Company.Contract.Services
{
    public interface ICompanyService
    {
        public Task<CompanyResponse> Create(ChangeCompanyRequest request);
        public Task<CompanyResponse> Update(string id, ChangeCompanyRequest request);
        public Task<AllCompaniesResponse> All();
        public Task Delete(string id);
    }
}