using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using System.Security.Claims;
using Task = System.Threading.Tasks.Task;
namespace aspdotnetwebapi.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<List<Homework?>> GetHomeworkAllAsync();
        Task<Homework> CreateHomeworkAsync(ClaimsPrincipal claims, Guid taskId, HomeworkDto homeworkDto);
        Task<Homework?> UpdateHomeworkAsync(ClaimsPrincipal claims, Guid taskId, HomeworkDto homeworkDto);
        Task DeleteHomeworkAsync(Guid id);
    }
}
