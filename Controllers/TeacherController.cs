using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TeacherController : DbController<Teacher, TeacherRepository>
    {
        public TeacherController(TeacherRepository repository) : base(repository) { }
    }
}
