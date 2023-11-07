using MathLearner.Domain.Entities;
using MathLearnerWasmApp.StaticClasses;

namespace MathLearnerWasmApp.Services.UserService
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(HttpClient httpClient) : base(httpClient, SiteConstants.Controller.User)
        {
        }
    }
}
