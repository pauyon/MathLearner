namespace MathLearnerWasmApp.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
    }
}
