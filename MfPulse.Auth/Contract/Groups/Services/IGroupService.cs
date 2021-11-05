using System.Threading.Tasks;
using MfPulse.Auth.Contract.Groups.Models.Requests;
using MfPulse.Auth.Contract.Groups.Models.Responses;

namespace MfPulse.Auth.Contract.Groups.Services
{
    public interface IGroupService
    {
        public Task<GroupResponse> Create(CreateGroupRequest request);
        public Task<GroupResponse> Update(UpdateGroupRequest request);
        public Task Delete(string id);
        public Task<AllGroupsResponse> All();
        public Task<GroupResponse> Get(string id);
    }
}