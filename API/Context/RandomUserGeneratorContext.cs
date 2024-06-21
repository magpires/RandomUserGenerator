using API.Configurations;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class RandomUserGeneratorContext : DbContext
    {
        public RandomUserGeneratorContext(DbContextOptions<RandomUserGeneratorContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
