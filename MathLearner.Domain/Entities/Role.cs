using MathLearner.Domain.Entities.Interfaces;

namespace MathLearner.Domain.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
