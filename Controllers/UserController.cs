using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser(UserDto usersDto) => Ok(await _userRepository.CreateUserAsync(usersDto));

        [HttpGet, Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
        public async Task<ActionResult> GetAllUsers() => Ok(await _userRepository.GetUserAllAsync() ?? new List<User?>());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserAsync(Guid Id) => Ok(await _userRepository.GetUserAsync(Id));

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(string email, UserDto usersDto)
        {
            var users = await _userRepository.UpdateUserAsync(email, usersDto);
            if (users is null)
                return NotFound("This User is not Defined");
            return Ok(users);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
            return Ok("User is Deleted");
        }
    }
}
