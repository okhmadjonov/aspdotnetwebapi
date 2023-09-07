using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using Task = System.Threading.Tasks.Task;
namespace aspdotnetwebapi.Interfaces
{
    public interface ICourseRepository
    {

        Task<List<Course?>> GetCourseAllAsync();
        Task<Course?> GetCourseByIdAsync(Guid id);
        Task<Course> CreateCourseAsync(CourseDto courseDto);
        Task<Course?> UpdateCourseAsync(CourseDto courseDto);
        Task DeleteCourseAsync(Guid id);
    }
}
