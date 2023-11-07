using MathLearner.Domain.Entities;

namespace MathLearnerWasmApp.Services.RoleService
{
    public interface IRoleService
    {
        Task<List<Role>?> GetAll();
    }
}
