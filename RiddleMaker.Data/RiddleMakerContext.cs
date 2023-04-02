using Microsoft.EntityFrameworkCore;
using RiddleMaker.Common.DataConfiguration;
using RiddleMaker.Data.Models;

namespace RiddleMaker.Data
{
    public class RiddleMakerContext : DbContext
    {
        public RiddleMakerContext()
        {
            
        }

        public RiddleMakerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Riddle> Riddles { get; set; } = null!;

        public DbSet<Answer> Answers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionConfiguration.ConnectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
