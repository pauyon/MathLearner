using MathLearner.Domain.Repositories;

namespace MathLearner.PersistenceCoreEF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(dbContext);
            RoleRepository = new RoleRepository(dbContext);
        }

        public IUserRepository UserRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
    }
}
