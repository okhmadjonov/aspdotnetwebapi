using aspdotnetwebapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task = aspdotnetwebapi.Entities.Task;
namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskController : DbController<Task, TaskRepository>
    {
        public TaskController(TaskRepository repository) : base(repository)
        {

        }
    }
}
