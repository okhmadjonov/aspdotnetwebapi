using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;
        public ResultController(IResultRepository resultRepository) => _resultRepository = resultRepository;

        [HttpGet]
        public async Task<IActionResult> GetComments() => Ok(await _resultRepository.GetResultAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(Guid id) => Ok(await _resultRepository.GetResultByIdAsync(id));

        [HttpPost]

        public async Task<IActionResult> WriteCommentAsync(Guid taskId, ResultDto resultDto) => Ok(await _resultRepository.AddResultAsync(User, taskId, resultDto));

        [HttpPut]
        public async Task<IActionResult> UpdateCommentAsync(Guid taskId, ResultDto resultDto) => Ok(await _resultRepository.UpdateResultAsync(User, taskId, resultDto));

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            await _resultRepository.GetResultAllAsync();
            return Ok("User is Deleted");
        }
    }
}
