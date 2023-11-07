namespace MathLearner.Domain.Models
{
    public class RefreshToken
    {
        public string Token { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateExpires { get; set; } = DateTime.Now.AddHours(1);
    }
}
