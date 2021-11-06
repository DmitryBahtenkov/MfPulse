using System.Threading.Tasks;
using MfPulse.Auth.Contract.Requests;
using MfPulse.Auth.Contract.Responses;
using MfPulse.Auth.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfPulse.Api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/v1/user")]
        public async Task<UserResponse> Create([FromBody] CreateUserRequest request)
            => await _userService.Create(request);
        
        [HttpPut("api/v1/user/{id}")]
        public async Task<UserResponse> Update(string id, [FromBody] UpdateUserRequest request)
            => await _userService.Update(id, request);
    }
}