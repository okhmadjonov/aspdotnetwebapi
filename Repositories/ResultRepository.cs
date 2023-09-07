using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace aspdotnetwebapi.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly DataContext _dataContext;

        public ResultRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<Result> AddResultAsync(ClaimsPrincipal claims, Guid descriptionId, ResultDto resultDto)
        {
            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _dataContext.Results.FindAsync(userId);
            if (result == null)
            {
                result = new Result()
                {
                    Id = new Guid(),
                    UserId = userId,
                    ImgPath = resultDto.ImgPath,
                    DescriptionCourseId = descriptionId
                };
                await _dataContext.AddAsync(result);
                await _dataContext.SaveChangesAsync();
            }

            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();

            return result;
        }

        public async System.Threading.Tasks.Task DeleteResultAsync(Guid id)
        {
            var result = await _dataContext.Results.FirstOrDefaultAsync(i => i.Id == id);
            _dataContext.Remove(result);
            _dataContext.SaveChanges();

        }

        public async Task<List<Result>> GetResultAllAsync()
        {
            return await _dataContext.Results.ToListAsync();
        }

        public async Task<Result> GetResultByIdAsync(Guid id)
        {
            return await _dataContext.Results.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Result> UpdateResultAsync(ClaimsPrincipal claims, Guid descriptionId, ResultDto resultDto)
        {



            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _dataContext.Results.FindAsync(userId);

            if (result == null)
            {
                return result;
            }

            result.ImgPath = resultDto.ImgPath;
            result.DescriptionCourseId = descriptionId;

            await _dataContext.AddAsync(result);
            await _dataContext.SaveChangesAsync();
            return result;


        }
    }
}
