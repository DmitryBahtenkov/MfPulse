using System;
using System.Linq;
using System.Threading.Tasks;
using MfPulse.Auth.Contract.Companies.Models;
using MfPulse.Auth.Contract.Companies.Models.Requests;
using MfPulse.Auth.Contract.Companies.Models.Responses;
using MfPulse.Auth.Contract.Companies.Operations;
using MfPulse.Auth.Contract.Companies.Services;
using MfPulse.CrossCutting.Exceptions;
using MfPulse.EventBus;
using MfPulse.EventBus.Events;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Auth.Implementation.Companies.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyGetOperations _companyGetOperations;
        private readonly ICompanyWriteOperations _companyWriteOperations;
        private readonly EventInvoker<CompanyDocument> _eventInvoker;
        private readonly IServiceProvider _serviceProvider;

        public CompanyService(ICompanyGetOperations companyGetOperations,
            ICompanyWriteOperations companyWriteOperations,
            EventInvoker<CompanyDocument> eventInvoker, IServiceProvider serviceProvider)
        {
            _companyGetOperations = companyGetOperations;
            _companyWriteOperations = companyWriteOperations;
            _eventInvoker = eventInvoker;
            _serviceProvider = serviceProvider;
        }

        public async Task<CompanyResponse> Create(ChangeCompanyRequest request)
        {
            if (await _companyGetOperations.ExistById(request.Id))
            {
                throw new BusinessException($"Компания с таким Id уже существует. {request.Id}");
            }
            
            var newDoc = new CompanyDocument
            {
                Id = request.Id,
                Name = request.Name
            };

            var inserted = await _companyWriteOperations.Insert(newDoc);

            await _eventInvoker.OnDocumentCreated(
                new DocumentCreatedEvent<CompanyDocument>(_serviceProvider, inserted));
            
            return new()
            {
                Id = inserted.Id,
                Name = inserted.Name
            };
        }

        public async Task<CompanyResponse> Update(ChangeCompanyRequest request)
        {
            var updated = await _companyWriteOperations.UpdateName(request.Id, request.Name);
            
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