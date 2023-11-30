namespace MathLearner.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IQuizRepository QuizRepository { get; }
        int Save();
    }
}
