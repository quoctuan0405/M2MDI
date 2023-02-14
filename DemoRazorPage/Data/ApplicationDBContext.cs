using DemoRazorPage.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoRazorPage.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; } 

    }
}
