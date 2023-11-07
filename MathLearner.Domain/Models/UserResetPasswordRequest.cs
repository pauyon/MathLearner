using System.ComponentModel.DataAnnotations;

namespace MathLearner.Domain.Models
{
    public class UserResetPasswordRequest
    {
        [Required]
        public string ResetPasswordToken { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
