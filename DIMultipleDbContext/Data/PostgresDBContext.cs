using DIMultipleDbContext.Model;
using Microsoft.EntityFrameworkCore;

namespace DIMultipleDbContext.Data
{
    public class PostgresDBContext : DbContext
    {
        public DbSet<Set> Sets { get; set; }

        public PostgresDBContext(DbContextOptions<PostgresDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
