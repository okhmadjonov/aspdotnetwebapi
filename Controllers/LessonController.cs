using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LessonController : DbController<Lesson, LessonRepository>
    {
        public LessonController(LessonRepository repository) : base(repository)
        {

        }
    }
}
