using MathLearner.Domain.Entities.Interfaces;

namespace MathLearner.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[byte.MaxValue];
        public byte[] PasswordSalt { get; set; } = new byte[byte.MaxValue];
        public string RefreshToken { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public IEnumerable<Role> Roles { get; set; } = new List<Role>();
    }
}
