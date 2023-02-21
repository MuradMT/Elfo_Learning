using System.Linq;
using System.Linq.Expressions;
using Elfo_Learning.Context;
using Microsoft.EntityFrameworkCore;

namespace Elfo_Learning.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()

    {
        private ElfoContext _dbContext;
        public BaseRepository(ElfoContext elfoContext)
        {
            _dbContext = elfoContext;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
           
             _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return await  _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {

            return expression == null ? _dbContext.Set<TEntity>().ToList() :  _dbContext.Set<TEntity>().Where(expression).ToList();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
