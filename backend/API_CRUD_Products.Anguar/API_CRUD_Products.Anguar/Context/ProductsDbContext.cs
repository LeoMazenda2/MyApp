using API_CRUD_Products.Anguar.Model;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_Products.Anguar.Context;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

    public ProductsDbContext() {}

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        // Alterando convenções do EF Core
        configuration.Properties<string>().HaveMaxLength(100);
        configuration.Properties<decimal>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

}
