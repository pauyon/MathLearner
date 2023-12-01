using System.Linq.Expressions;

namespace MathLearner.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null);
        Task<T?> Get(Expression<Func<T, bool>> predicate, bool tracked = true);
        Task<T> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        Task<bool> Update(T entity);
        Task SaveChanges();
    }
}
