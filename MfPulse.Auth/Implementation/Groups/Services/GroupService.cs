using System.Linq;
using System.Threading.Tasks;
using MfPulse.Auth.Contract.Database.Operations;
using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Auth.Contract.Groups.Models.Requests;
using MfPulse.Auth.Contract.Groups.Models.Responses;
using MfPulse.Auth.Contract.Groups.Operations;
using MfPulse.Auth.Contract.Groups.Services;
using MfPulse.Auth.Contract.Services;
using MfPulse.CrossCutting.Exceptions;

namespace MfPulse.Auth.Implementation.Groups.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupGetOperations _groupGetOperations;
        private readonly IGroupWriteOperations _groupWriteOperations;
        private readonly IUserGetOperations _userGetOperations;
        private readonly IUserIdentity _userIdentity;

        public GroupService(IGroupGetOperations groupGetOperations, IGroupWriteOperations groupWriteOperations,
            IUserGetOperations userGetOperations, IUserIdentity userIdentity)
        {
            _groupGetOperations = groupGetOperations;
            _groupWriteOperations = groupWriteOperations;
            _userGetOperations = userGetOperations;
            _userIdentity = userIdentity;
        }

        public async Task<GroupResponse> Create(CreateGroupRequest request)
        {
            await CheckResponsible(request.ResponsibleId);
            var document = await _groupWriteOperations.Insert(new GroupDocument
            {
                Name = request.Name,
                ResponsibleId = request.ResponsibleId,
                CompanyId = _userIdentity.User.CompanyId
            });

            return new()
            {
                Name = document.Name,
                Id = document.Id
            };
        }

        public async Task<GroupResponse> Update(string id, UpdateGroupRequest request)
        {
            await CheckResponsible(request.ResponsibleId);

            var document = await _groupWriteOperations.UpdateInfo(id, request.Name, request.ResponsibleId);
            
            return new()
            {
                Name = document.Name,
                Id = document.Id
            };
        }

        private async Task CheckResponsible(string responsibleId)
        {
            var user = await _userGetOperations.ById(responsibleId);
            if (user is null)
            {
                throw new BusinessException("Ответственный не найден");
            }
        }

        public async Task Delete(string id)
        {
            var document = await _groupGetOperations.ById(id);
            if (document is not null)
            {
                await _groupWriteOperations.Delete(document);
            }
        }

        public async Task<AllGroupsResponse> All()
        {
            var docs = await _groupGetOperations.All();
            return new()
            {
                Groups = docs.Select(x => new GroupResponse
                {
                    Name = x.Name,
                    Id = x.Id
                }).ToList()
            };
        }

        public async Task<GroupResponse> Get(string id)
        {
            var document = await _groupGetOperations.ById(id);

            if (document is null)
            {
                throw new NotFoundException();
            }

            return new()
            {
                Id = document.Id,
                Name = document.Name
            };
        }
    }
}