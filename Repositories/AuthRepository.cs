using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.ExtationFunction;
using aspdotnetwebapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aspdotnetwebapi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context) => _context = context;

        public async Task<User> Register(UserDto request)
        {
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

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string> Login(UserDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == request.Email);

            if (user != null)
            {
                var verify = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
                if (verify)
                {
                    var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user);
                    return token;
                }
                else throw new BadHttpRequestException("Wrong password");
            }

            throw new BadHttpRequestException("User not found.");
        }

        public async Task<List<User>> GetAllUsers() => await _context.Users.ToListAsync();




    }
}
