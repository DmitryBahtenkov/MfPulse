using System.Threading.Tasks;
using MfPulse.Auth.Contract.Companies.Models.Requests;
using MfPulse.Auth.Contract.Companies.Models.Responses;

namespace MfPulse.Auth.Contract.Companies.Services
{
    public interface ICompanyService
    {
        public Task<CompanyResponse> Create(ChangeCompanyRequest request);
        public Task<CompanyResponse> Update(ChangeCompanyRequest request);
        public Task<AllCompaniesResponse> All();
        public Task Delete(string id);
    }
}