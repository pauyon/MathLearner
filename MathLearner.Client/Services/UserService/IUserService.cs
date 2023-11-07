using MathLearner.Domain.Entities;

namespace MathLearnerWasmApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>?> GetAll();
    }
}
