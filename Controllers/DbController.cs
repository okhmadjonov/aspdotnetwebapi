using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Services;
using aspdotnetwebapi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]

    public class DbController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IGenericService<TEntity>
    {

        private readonly IGenericService<TEntity> _genericService;

        internal DbController(IGenericService<TEntity> genericService) => _genericService = genericService;

        [HttpGet]

        public async Task<ActionResult<IEnumerable<TEntity>>> Get() => await _genericService.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(Guid id)
        {
            var movie = await _genericService.Get(id);
            if (movie == null) return NotFound();
            return movie;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, TEntity movie)
        {
            if (id != movie.Id)
                return BadRequest();
            await _genericService.Update(movie);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity movie)
        {
            await _genericService.Add(movie);
            return (movie);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            var movie = await _genericService.Delete(id);
            return movie;
        }

    }
}
