using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using Task = System.Threading.Tasks.Task;

namespace aspdotnetwebapi.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid id);
        Task<List<User?>> GetUserAllAsync();
        Task<User> CreateUserAsync(UserDto usersDto);
        Task<User> UpdateUserAsync(string email, UserDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}
