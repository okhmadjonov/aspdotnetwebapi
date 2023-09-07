using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace aspdotnetwebapi.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly DataContext _dataContext;

        public HomeworkRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Homework> CreateHomeworkAsync(ClaimsPrincipal claims, Guid taskId, HomeworkDto homeworkDto)
        {
            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var homework = new Homework()
            {
                Id = new Guid(),
                ImgUrl = homeworkDto.ImgUrl,
                Name = homeworkDto.Name,
                TaskId = taskId,
                UserId = userId
            };

            await _dataContext.Homework.AddAsync(homework);
            await _dataContext.SaveChangesAsync();

            return homework;
        }

        public async System.Threading.Tasks.Task DeleteHomeworkAsync(Guid id)
        {
            var homework = await _dataContext.Homework.FirstOrDefaultAsync(i => i.Id == id);
            if (homework != null) _dataContext.Homework.Remove(homework);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Homework?>> GetHomeworkAllAsync()
        {
            return await _dataContext.Homework.ToListAsync();
        }

        public async Task<Homework?> UpdateHomeworkAsync(ClaimsPrincipal claims, Guid taskId, HomeworkDto homeworkDto)
        {

            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var findHomework = await _dataContext.Homework.FirstOrDefaultAsync(u => u.Name == homeworkDto.Name);

            if (findHomework == null) return findHomework;
            findHomework.UserId = userId;
            findHomework.Name = homeworkDto.Name;
            findHomework.ImgUrl = homeworkDto.ImgUrl;
            findHomework.TaskId = taskId;

            await _dataContext.SaveChangesAsync();

            return findHomework;

        }
    }
}
