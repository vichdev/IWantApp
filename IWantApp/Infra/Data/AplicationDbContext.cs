namespace IWantApp.Infra.Data;

using Flunt.Notifications;
using IWantApp.Domain.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        builder.Entity<Product>().Property(product => product.Name).IsRequired();

        builder.Entity<Product>().Property(product => product.Description).HasMaxLength(500);

        builder.Entity<Category>().Property(category => category.Name).IsRequired();

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {

        configuration.Properties<string>().HaveMaxLength(100);

    }




}
