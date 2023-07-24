namespace IWantApp.Infra.Data;

using Flunt.Notifications;
using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

public class AplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {

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
