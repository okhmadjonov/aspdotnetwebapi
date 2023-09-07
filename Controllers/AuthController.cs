using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository) => _authRepository = authRepository;

        [HttpGet("ListUsers"), Authorize]
        public async Task<IActionResult> GetAllUsers() => Ok(await _authRepository.GetAllUsers());

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request) =>
            Ok(await _authRepository.Register(request));

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request) => Ok(await _authRepository.Login(request));
    }
}


