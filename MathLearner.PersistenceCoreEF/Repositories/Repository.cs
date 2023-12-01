using MathLearner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MathLearner.PersistenceCoreEF.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dbContext;

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await SaveChanges();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate, bool tracked = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            query = query.Where(predicate);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);

            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await SaveChanges();

                return true;
            }

            return false;
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            await SaveChanges();
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                await SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
