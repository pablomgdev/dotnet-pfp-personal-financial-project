using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityFramework.Models.Configuration;

public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id).HasName("categories_pkey");

        builder.ToTable("categories");

        builder.HasIndex(e => e.Name, "categories_name_key").IsUnique();

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.CreatedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_date");
        builder.Property(e => e.DeletedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("deleted_date");
        builder.Property(e => e.IsDeleted)
            .HasColumnType("boolean")
            .HasColumnName("is_deleted");
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        builder.Property(e => e.UpdatedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_date");
        builder.Property(e => e.UserId).HasColumnName("user_id");
    }
}