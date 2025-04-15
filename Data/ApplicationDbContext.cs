using Customers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Customers.Data;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> Individuals { get; set; }
    public DbSet<BusinessCustomer> Businesses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure OpenIddict
        builder.UseOpenIddict();
        
        // Configure Enums
        builder.HasPostgresEnum<CustomerType>();

        // Configure Relations
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Customer)
            .WithOne(c => c.User)
            .HasForeignKey<Customer>(c => c.Id);

        builder.Entity<Customer>()
            .HasKey(c => c.Id);

        builder.Entity<Customer>()
            .HasOne(c => c.Individual)
            .WithOne(i => i.Customer)
            .HasForeignKey<IndividualCustomer>(i => i.CustomerId);

        builder.Entity<Customer>()
            .HasOne(c => c.Business)
            .WithOne(b => b.Customer)
            .HasForeignKey<BusinessCustomer>(b => b.CustomerId);
        
        builder.Entity<IndividualCustomer>()
            .HasKey(i => i.CustomerId);

        builder.Entity<BusinessCustomer>()
            .HasKey(b => b.CustomerId);
    }
}