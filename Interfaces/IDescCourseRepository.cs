using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using Task = System.Threading.Tasks.Task;

namespace aspdotnetwebapi.Interfaces
{
    public interface IDescCourseRepository
    {
        Task<List<DescCourse>> GetDescriptionAllAsync();
        Task<DescCourse> GetDescriptionByIdAsync(Guid id);
        Task<DescCourse> CreateDescription(DescCourseDto descriptionCourseDto);
        Task<DescCourse?> UpdateDescriptionAsync(Guid id, DescCourseDto descriptionCourseDto);
        Task DeleteDescriptionAsync(Guid id);
    }
}
