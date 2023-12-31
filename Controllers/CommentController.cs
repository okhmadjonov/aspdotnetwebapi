﻿using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository) => _commentRepository = commentRepository;

        [HttpGet]
        public async Task<IActionResult> GetComments() => Ok(await _commentRepository.GetCommentAllAsync());

        [HttpPost]

        public async Task<IActionResult> WriteCommentAsync(Guid taskId, CommentDto commentDto) => Ok(await _commentRepository.WriteCommentAsync(User, taskId, commentDto));

        [HttpPut]

        public async Task<IActionResult> UpdateCommentAsync(Guid taskId, CommentDto commentDto) => Ok(await _commentRepository.UpdateCommentAsync(User, taskId, commentDto));

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            await _commentRepository.DeleteCommentAsync(id);
            return Ok("User is Deleted");
        }

    }
}
