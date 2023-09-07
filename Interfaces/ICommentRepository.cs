using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using System.Security.Claims;
using Task = System.Threading.Tasks.Task;

namespace aspdotnetwebapi.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment?>> GetCommentAllAsync();
        Task<Comment> WriteCommentAsync(ClaimsPrincipal claims, Guid taskId, CommentDto commentDto);
        Task<Comment?> UpdateCommentAsync(ClaimsPrincipal claims, Guid taskId, CommentDto commentDto);
        Task DeleteCommentAsync(Guid id);
    }
}
