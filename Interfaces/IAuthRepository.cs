using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;

namespace aspdotnetwebapi.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
        Task<List<User>> GetAllUsers();
    }
}
