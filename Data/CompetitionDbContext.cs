using Microsoft.EntityFrameworkCore;

using CompetitionTrackerAPI.Models;

namespace CompetitionTrackerAPI.Data
{
    public class CompetitionDbContext : DbContext
    {
        public CompetitionDbContext(DbContextOptions<CompetitionDbContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        
    }
}



