using System.Linq.Expressions;

namespace Elfo_Learning.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T,bool>> expression=null);
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
