using aspdotnetwebapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspdotnetwebapi.Services
{
    public class GenericService<TEntity, TContext> : IGenericService<TEntity>
        where TEntity : class, IEntity
        where TContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly TContext _context;

        public GenericService(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            entity.Id = new Guid();
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null) return entity;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity?> Get(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
