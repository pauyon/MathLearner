
using MathLearner.Domain.Entities.Interfaces;

namespace MathLearner.Domain.Entities
{
    public class Quiz : EntityBase
    {
        public string? Name { get; set; }
        public List<Question>? Questions { get; set; }
        public int? CorrectAnswers { get; set; }
        public int? IncorrectAnswers { get; set; }
        public int? TotalQuestions { get; set; }
        public char? LetterGrade { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
