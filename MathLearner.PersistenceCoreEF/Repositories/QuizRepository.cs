using MathLearner.Domain.Entities;
using MathLearner.Domain.Repositories;

namespace MathLearner.PersistenceCoreEF.Repositories
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        public QuizRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
