using MathLearner.Domain.Entities;
using MathLearner.Domain.Repositories;

namespace MathLearner.PersistenceDatabaseEF.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base (dbContext)
        {
        }
    }
}
