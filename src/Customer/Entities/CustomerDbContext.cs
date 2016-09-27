using Microsoft.EntityFrameworkCore;

namespace MVCCustomer.Entities
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasAlternateKey(x => x.Email)
                .HasName("AlternateKey_Email");
        }
    }
}
