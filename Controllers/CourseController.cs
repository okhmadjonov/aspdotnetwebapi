using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CourseController : DbController<Course, CourseRepository>
    {
        public CourseController(CourseRepository repository) : base(repository)
        {

        }
    }
}
