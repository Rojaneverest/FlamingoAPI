using ecommerce.Data;
using ecommerce.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Core.Base
{
    public class BaseDao<E> where E : class
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<E> _dbSet;

        public BaseDao(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<E>();
        }

        public IQueryable<E> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<E?> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<E> Create(E entity)
        {
            var adedEntity = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return adedEntity.Entity;
        }

        public async Task<E> Update(string id, E entity)
        {
            dynamic dynamicEntity = entity;
            dynamicEntity.Id = id;
            var updatedEntity = _dbSet.Update(dynamicEntity);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<E> Delete(string id)
        {
            var entity = await GetById(id) ?? throw new BadHttpRequestException("User not found"); // TODO Use module name
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }

}