using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewController : DbController<Review, ReviewRepository>
    {
        public ReviewController(ReviewRepository repository) : base(repository) { }
    }
}
