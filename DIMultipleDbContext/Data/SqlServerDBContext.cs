using DIMultipleDbContext.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DIMultipleDbContext.Data
{
    public class SqlServerDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public SqlServerDBContext()
        {

        }

        public SqlServerDBContext(DbContextOptions<SqlServerDBContext> options): base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=root;database=AnotherTest;Trusted_Connection=true;Trust Server Certificate=True");

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
