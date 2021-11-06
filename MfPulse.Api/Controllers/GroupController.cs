using System.Threading.Tasks;
using MfPulse.Api.Attributes;
using MfPulse.Auth.Contract.Groups.Models;
using MfPulse.Auth.Contract.Groups.Models.Requests;
using MfPulse.Auth.Contract.Groups.Models.Responses;
using MfPulse.Auth.Contract.Groups.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfPulse.Api.Controllers
{
    [Route("api/v1/group")]
    [ApiController]
    [ForAdmins]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<GroupResponse> Create([FromBody] CreateGroupRequest request)
            => await _groupService.Create(request);

        [HttpPut("{id}")]
        public async Task<GroupResponse> Update(string id, [FromBody] UpdateGroupRequest request)
            => await _groupService.Update(id, request);

        [HttpGet("all")]
        public async Task<AllGroupsResponse> All()
            => await _groupService.All();

        [HttpGet("{id}")]
        public async Task<GroupResponse> Get(string id)
            => await _groupService.Get(id);
    }
}