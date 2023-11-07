using MathLearner.Domain.Dtos;
using MathLearner.Domain.Entities;
using MathLearner.Api.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace MathLearner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var result = await _authService.Register(request);

            if (result == null)
            {
                return BadRequest("Account could not be created.");
            }

            return Ok(result);
        }

        //[HttpPost("refreshtoken")]
        //public async Task<ActionResult<string>> RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];

        //    if (!_user.RefreshToken.Equals(refreshToken))
        //    {
        //        return Unauthorized("Invalid refresh token.");
        //    }
        //    else if (_user.TokenDateExpires < DateTime.Now)
        //    {
        //        return Unauthorized("Token has expired.");
        //    }

        //    string token = CreateToken(_user);
        //    var newRefreshToken = GenerateRefreshToken();
        //    SetRefreshToken(newRefreshToken);

        //    return Ok(newRefreshToken);
        //}

        [HttpPost("login")]
        public async Task<ActionResult<User?>> Login(UserDto request)
        {
            var result = await _authService.Login(request);

            if (result == null)
            {
                return BadRequest("Couldn't log in.");
            }

            return Ok(result);
        }
    }
}
