using MathLearner.Domain.Dtos;
using MathLearner.Domain.Entities;

namespace MathLearner.Api.Services.AuthService
{
    public interface IAuthService
    {
        Task<User> Register(UserDto request);

        Task<User?> Login(UserDto request);
    }
}
