using Microsoft.EntityFrameworkCore;

namespace Mission10Backend.Data
{
    public class BowlerDbContext : DbContext 
    {
        public BowlerDbContext(DbContextOptions<BowlerDbContext> options) : base(options)
        {
        }
        
        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bowler>().ToTable("Bowlers");
            modelBuilder.Entity<Team>().ToTable("Teams");
        }
    }
}