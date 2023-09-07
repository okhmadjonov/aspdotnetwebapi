using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.Services;
using Task = aspdotnetwebapi.Entities.Task;

namespace aspdotnetwebapi.Repositories
{
    public class TaskRepository : GenericService<Task, DataContext>
    {
        public TaskRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
