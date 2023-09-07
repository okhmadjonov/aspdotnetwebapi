using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using Task = System.Threading.Tasks.Task;
namespace aspdotnetwebapi.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher?>> GetTeacherAllAsync();
        Task<Teacher> CreateTeacherAsync(TeacherDto teacherDto);
        Task<Teacher?> UpdateTeacherAsync(string fullName, TeacherDto teacherDto);
        Task DeleteTeacherAsync(Guid id);
    }
}
