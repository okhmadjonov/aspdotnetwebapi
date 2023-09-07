using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace aspdotnetwebapi.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DataContext _dataContext;

        public CommentRepository(DataContext dataContext) => _dataContext = dataContext;

        public async System.Threading.Tasks.Task DeleteCommentAsync(Guid id)
        {
            var comment = await _dataContext.Comments.FirstOrDefaultAsync(i => i.Id == id);
            if (comment != null) _dataContext.Comments.Remove(comment);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Comment?>> GetCommentAllAsync() =>
            await _dataContext.Comments.ToListAsync() ?? new List<Comment>();

        public async Task<Comment?> UpdateCommentAsync(ClaimsPrincipal claims, Guid taskId, CommentDto commentDto)
        {
            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var comment = await _dataContext.Comments.FindAsync(userId);

            if (comment == null)
            {
                return comment;
            }

            comment.Desc = commentDto.Desc;
            comment.DocumentPath = commentDto.DocumentPath;
            comment.TaskId = taskId;

            await _dataContext.AddAsync(comment);
            await _dataContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> WriteCommentAsync(ClaimsPrincipal claims, Guid taskId, CommentDto commentDto)
        {

            var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var comment = await _dataContext.Comments.FindAsync(userId);
            if (comment == null)
            {
                comment = new Comment()
                {
                    UserId = userId,
                    Desc = commentDto.Desc,
                    DocumentPath = commentDto.DocumentPath,
                    TaskId = taskId,
                };
                await _dataContext.AddAsync(comment);
                await _dataContext.SaveChangesAsync();
            }

            await _dataContext.AddAsync(comment);
            await _dataContext.SaveChangesAsync();

            return comment;
        }
    }
}
