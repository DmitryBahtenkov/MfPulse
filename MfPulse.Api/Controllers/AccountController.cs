using System.Threading.Tasks;
using MfPulse.Auth.Contract.Requests;
using MfPulse.Auth.Contract.Responses;
using MfPulse.Auth.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfPulse.Api.Controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<UserResponse> Login([FromBody] LoginRequest request)
            => await _authService.Login(request);
        
        [HttpPost("logout/{id}")]
        public async Task Login(string id)
            => await _authService.Logout(id);
    }
}