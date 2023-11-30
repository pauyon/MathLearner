using MathLearner.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MathLearner.PersistenceCoreEF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role() { Id = 1, Name = "Admin", Description = "Admin", IsActive = true },
                    new Role() { Id = 2, Name = "Student", Description = "Student", IsActive = true }
                );

            modelBuilder.Entity<User>().HasData(
                    new User() { Id = 1, Username = "pauyon", Email = "pauyon@test.com", IsActive = true },
                    new User() { Id = 2, Username = "jsalmeron", Email = "jsalmeron@test.com", IsActive = true }
                );
        }
    }
}
