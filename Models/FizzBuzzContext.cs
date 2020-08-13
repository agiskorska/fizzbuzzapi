using Microsoft.EntityFrameworkCore;

namespace FizzBuzzApi.Models
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext(DbContextOptions<FizzBuzzContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<FizzBuzzRule> FizzBuzzRules { get; set; }
    }
}