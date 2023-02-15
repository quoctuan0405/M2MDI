using DemoRazorPage.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car()
                {
                    Id = 1,
                    Name = "Car 1",
                    Manufacture = "Manufacture 1",
                    Price = 10000,
                    Quantity = 10,
                    ReleaseYear = 2000
                },
                new Car()
                {
                    Id = 2,
                    Name = "Car 2",
                    Manufacture = "Manufacture 2",
                    Price = 20000,
                    Quantity = 15,
                    ReleaseYear = 2002
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Username = "username",
                },
                new User()
                {
                    Id = 2,
                    Username = "username1"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
