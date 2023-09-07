using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DescController : DbController<DescCourse, DescCourseRepository>
    {
        public DescController(DescCourseRepository descCourseRepository) : base(descCourseRepository)
        {

        }
    }
}
