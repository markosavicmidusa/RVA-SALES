using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
/*using StackExchange.Redis;
*/


namespace RVAPRODAVNICA.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /*
        public DbSet<Order> Orders { get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }*/
    }
}