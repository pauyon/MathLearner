using MathLearner.Domain.Entities;
using MathLearnerWasmApp.StaticClasses;

namespace MathLearnerWasmApp.Services.RoleService
{
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(HttpClient httpClient) : base(httpClient, SiteConstants.Controller.Role)
        {
        }
    }
}
