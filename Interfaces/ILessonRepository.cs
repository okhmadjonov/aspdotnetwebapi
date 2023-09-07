using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using Task = System.Threading.Tasks.Task;
namespace aspdotnetwebapi.Interfaces
{
    public interface ILessonRepository
    {
        Task<Lesson> GetLessonAsync(Guid id);
        Task<List<Lesson>> GetLessonAllAsync();
        Task<Lesson> AddLessonAsync(LessonDto lessonDto);
        Task<Lesson> UpdateLessonAsync(Guid id, LessonDto lessonDto);
        Task DeleteLessonAsync(Guid id);
    }
}
