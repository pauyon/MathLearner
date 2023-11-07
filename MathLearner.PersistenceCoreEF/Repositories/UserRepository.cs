using MathLearner.Domain.Entities;
using MathLearner.Domain.Repositories;

namespace MathLearner.PersistenceCoreEF.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base (dbContext)
        {
        }
    }
}
