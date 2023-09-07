using aspdotnetwebapi.DTO;

namespace aspdotnetwebapi.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Entities.Task?>> GetTaskAllAsync();
        Task<Entities.Task?> GetTaskByIdAsync(Guid id);
        Task<Entities.Task> CreateTaskAsync(TaskDto taskDto);
        Task<Entities.Task?> UpdateTaskAsync(string name, TaskDto taskDto);
        Task DeleteTaskAsync(Guid id);
    }
}
