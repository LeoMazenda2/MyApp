using API_CRUD_Products.Anguar.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_CRUD_Products.Anguar.ModelsMappings;

public class ProductsMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Producto");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(55);
        builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow);
        builder.Property(x => x.Activated).HasDefaultValue(true);
    }
}
