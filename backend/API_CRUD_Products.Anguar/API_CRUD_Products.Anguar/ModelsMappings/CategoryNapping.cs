using API_CRUD_Products.Anguar.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_CRUD_Products.Anguar.ModelsMappings;

public class CategoryNapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {      

        builder.ToTable("Categoria");
        builder.HasKey(x => x.Id); 
        builder.Property(x => x.Activated).HasDefaultValue(true);
        builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow);

        builder.Property(x => x.CreatedDate).HasColumnType("DATETIME");// Define como DATETIME no MySQL

        builder.HasMany(c => c.Products)
               .WithOne(p => p.Category)
               .HasForeignKey(p => p.CategoryId);
    }
}
