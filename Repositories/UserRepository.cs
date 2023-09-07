using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace aspdotnetwebapi.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<User> CreateUserAsync(UserDto request)
        {
            //var user = userDto.Adapt<User>();
            /* await _dataContext.AddAsync(user);
             await _dataContext.SaveChangesAsync();
             return user;*/


            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);

            var user = new User
            {
                Id = new Guid(),
                Name = request.Name,
                Email = request.Email,
                Password = passwordHash
            };

            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;



        }

        public async System.Threading.Tasks.Task DeleteUserAsync(Guid id)
        {
            var deleteUser = await _dataContext.Users.FindAsync(id);
            _dataContext.Users.Remove(deleteUser);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<User?>> GetUserAllAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            return await _dataContext.Users.FindAsync(id);
        }

        public async Task<User> UpdateUserAsync(string email, UserDto userDto)
        {
            var findUser = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            findUser.Name = userDto.Name;
            findUser.Email = email;
            findUser.Password = userDto.Password;

            await _dataContext.SaveChangesAsync();

            return findUser;
        }
    }
}
