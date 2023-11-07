using MathLearner.Domain.Dtos;
using MathLearner.Domain.Entities;
using MathLearner.Domain.Models;
using MathLearner.PersistenceDatabaseEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MathLearner.Api.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dbContext;

        public AuthService(IConfiguration configuration, DataContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<User?> Login(UserDto request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username != request.Username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);

            return user;
        }

        public async Task<User> Register(UserDto request)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Username == request.Username);

            if (user != null)
            {
                return null;
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user = new User()
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Student"),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                DateExpires = DateTime.Now.AddHours(1),
                DateCreated = DateTime.Now,
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            //var cookieOptions = new CookieOptions
            //{
            //    HttpOnly = true,
            //    Expires = newRefreshToken.DateExpires,
            //};

            //Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            //_user.RefreshToken = newRefreshToken.Token;
            //_user.TokenDateCreated = newRefreshToken.DateCreated;
            //_user.TokenDateExpires = newRefreshToken.DateExpires;
        }
    }
}
