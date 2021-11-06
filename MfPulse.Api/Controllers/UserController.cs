using System.Threading.Tasks;
using MfPulse.Api.Attributes;
using MfPulse.Auth.Contract.Users.Database.Operations;
using MfPulse.Auth.Contract.Users.Requests;
using MfPulse.Auth.Contract.Users.Responses;
using MfPulse.Auth.Contract.Users.Services;
using MfPulse.Auth.Static.Rights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MfPulse.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [ForAdmins]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public async Task<UserResponse> Create([FromBody] CreateUserRequest request)
            => await _userService.Create(request);
        
        [HttpPut("{id}")]
        public async Task<UserResponse> Update(string id, [FromBody] UpdateUserRequest request)
            => await _userService.Update(id, request);
    }
}