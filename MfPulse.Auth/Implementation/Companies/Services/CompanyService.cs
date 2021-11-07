using System.Linq;
using System.Threading.Tasks;
using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.Auth.Contract.Companies.Models.Requests;
using MfPulse.Auth.Contract.Companies.Models.Responses;
using MfPulse.Auth.Contract.Companies.Operations;
using MfPulse.Auth.Contract.Companies.Services;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Auth.Implementation.Companies.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyGetOperations _companyGetOperations;
        private readonly ICompanyWriteOperations _companyWriteOperations;

        public CompanyService(ICompanyGetOperations companyGetOperations, ICompanyWriteOperations companyWriteOperations)
        {
            _companyGetOperations = companyGetOperations;
            _companyWriteOperations = companyWriteOperations;
        }

        public async Task<CompanyResponse> Create(ChangeCompanyRequest request)
        {
            var newDoc = new CompanyDocument
            {
                Id = IdGen.New,
                Name = request.Name
            };

            var inserted = await _companyWriteOperations.Insert(newDoc);

            return new()
            {
                Id = inserted.Id,
                Name = inserted.Name
            };
        }

        public async Task<CompanyResponse> Update(string id, ChangeCompanyRequest request)
        {
            var updated = await _companyWriteOperations.UpdateName(id, request.Name);
            
            return new()
            {
                Id = updated.Id,
                Name = updated.Name
            };
        }

        public async Task<AllCompaniesResponse> All()
        {
            var all = await _companyGetOperations.All();

            return new()
            {
                Companies = all.Select(x => new CompanyResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
        }

        public async Task Delete(string id)
        {
            var doc = await _companyGetOperations.ById(id);
            await _companyWriteOperations.Delete(doc);
        }
    }
}