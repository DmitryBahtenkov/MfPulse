#nullable enable
using System;
using System.Linq;
using System.Threading.Tasks;
using MfPulse.Assessment.Contract.Criterions.Models;
using MfPulse.Assessment.Contract.Criterions.Models.Requests;
using MfPulse.Assessment.Contract.Criterions.Models.Responses;
using MfPulse.Assessment.Contract.Criterions.Operations;
using MfPulse.Assessment.Contract.Criterions.Services;
using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Auth.Contract.Users.Services;
using MfPulse.CrossCutting.Exceptions;
using MfPulse.CrossCutting.Extensions;
using MfPulse.EventBus;
using MfPulse.EventBus.Events;
using MfPulse.Mongo.Helpers;

namespace MfPulse.Assessment.Implementations.Criterions.Services
{
    public class CriterionService : ICriterionService
    {
        private readonly ICriterionGetOperations _criterionGetOperations;
        private readonly ICriterionWriteOperations _criterionWriteOperations;
        private readonly IUserIdentity _userIdentity;
        private readonly EventInvoker<CriterionDocument> _eventInvoker;
        private readonly IServiceProvider _serviceProvider;
        private readonly IGroupGetOperations _groupGetOperations;

        public CriterionService(ICriterionGetOperations criterionGetOperations,
            ICriterionWriteOperations criterionWriteOperations,
            IUserIdentity userIdentity,
            EventInvoker<CriterionDocument> eventInvoker,
            IServiceProvider serviceProvider, 
            IGroupGetOperations groupGetOperations)
        {
            _criterionGetOperations = criterionGetOperations;
            _criterionWriteOperations = criterionWriteOperations;
            _userIdentity = userIdentity;
            _eventInvoker = eventInvoker;
            _serviceProvider = serviceProvider;
            _groupGetOperations = groupGetOperations;
        }

        public async Task<CriterionResponse> Create(CreateCriterionRequest request)
        {
            var group = await GetGroup(request.GroupId);

            var newDocument = new CriterionDocument
            {
                Id = IdGen.New,
                CompanyId = _userIdentity.CompanyId,
                GroupId = group?.Id,
                Name = request.Name
            };

            newDocument = await _criterionWriteOperations.Insert(newDocument);
            await _eventInvoker.OnDocumentCreated(
                new DocumentCreatedEvent<CriterionDocument>(_serviceProvider, newDocument));
            
            return new CriterionResponse
            {
                GroupId = group?.Id,
                GroupName = group?.Name,
                Name = newDocument.Name,
                Id = newDocument.Id
            };
        }

        private async Task<GroupDocument?> GetGroup(string? groupId)
        {
            if (string.IsNullOrEmpty(groupId))
            {
                return null;
            }

            var group = await _groupGetOperations.ById(groupId);
            
            if (group is null)
            {
                throw new BusinessException("Группа не найдена");
            }

            return group;
        }

        public async Task<CriterionResponse> Update(string id, UpdateCriterionRequest request)
        {
            var criterion = await _criterionWriteOperations.UpdateName(id, request.Name);
            if (criterion is null)
            {
                throw new BusinessException("Не найден критерий");
            }

            var group = await _groupGetOperations.ById(criterion.GroupId);

            return new CriterionResponse
            {
                Id = criterion.Id,
                Name = criterion.Name,
                GroupId = group?.Id,
                GroupName = group?.Name
            };
        }

        public async Task<CriterionResponse> Get(string id)
        {
            var criterion = await _criterionGetOperations.ById(id);

            if (criterion is null)
            {
                throw new NotFoundException();
            }

            var group = await _groupGetOperations.ById(criterion.GroupId);

            return new CriterionResponse
            {
                Id = criterion.Id,
                Name = criterion.Name,
                GroupId = group?.Id,
                GroupName = group?.Name
            };
        }

        public async Task<CriterionResponse> Map(CriterionDocument document)
        {
            var group = await _groupGetOperations.ById(document.GroupId);

            return new CriterionResponse
            {
                Id = document.Id,
                Name = document.Name,
                GroupId = group?.Id,
                GroupName = group?.Name
            };
        }

        public async Task<AllCriterionsResponse> ByGroup(string groupId)
        {
            var criterions = await _criterionGetOperations.ByGroup(groupId);

            var response = new AllCriterionsResponse
            {
                Criterions = await criterions.Select(async x => await Map(x)).ToListAsync()
            };

            return response;
        }

        public async Task<AllCriterionsResponse> All()
        {
            var criterions = await _criterionGetOperations.All();

            var response = new AllCriterionsResponse
            {
                Criterions = await criterions.Select(async x => await Map(x)).ToListAsync()
            };

            return response;
        }

        public async Task Delete(string id)
        {
            var document = await _criterionGetOperations.ById(id);

            if (document is not null)
            {
                document = await _criterionWriteOperations.Delete(document);
                
                await _eventInvoker.OnDocumentDeleted(
                    new DocumentDeletedEvent<CriterionDocument>(_serviceProvider, document));
            }
        }
    }
}