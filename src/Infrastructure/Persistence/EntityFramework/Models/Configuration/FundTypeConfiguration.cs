using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Models.Configuration;

public class FundTypeConfiguration : IEntityTypeConfiguration<Fund>
{
    public void Configure(EntityTypeBuilder<Fund> builder)
    {
        builder.HasKey(e => e.Id).HasName("funds_pkey");

        builder.ToTable("funds");

        builder.HasIndex(e => e.InternalId, "funds_internal_id_key").IsUnique();

        builder.HasIndex(e => e.Name, "funds_name_key").IsUnique();

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.CreatedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_date");
        builder.Property(e => e.DeletedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("deleted_date");
        builder.Property(e => e.Description)
            .HasMaxLength(255)
            .HasColumnName("description");
        builder.Property(e => e.InternalId)
            .IsRequired()
            .HasColumnName("internal_id");
        builder.Property(e => e.IsDeleted)
            .HasColumnType("boolean")
            .HasColumnName("is_deleted");
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        builder.Property(e => e.TotalAmount).HasColumnName("total_amount");
        builder.Property(e => e.UpdatedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_date");
        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.HasMany(d => d.Categories).WithMany(p => p.FundInternals)
            .UsingEntity<Dictionary<string, object>>(
                "FundsCategory",
                r => r.HasOne<Category>().WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__funds_categories__category_id__categories"),
                l => l.HasOne<Fund>().WithMany()
                    .HasPrincipalKey("InternalId")
                    .HasForeignKey("FundInternalId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__funds_categories__fund_internal_id__funds"),
                j =>
                {
                    j.HasKey("FundInternalId", "CategoryId").HasName("funds_categories_pkey");
                    j.ToTable("funds_categories");
                    j.IndexerProperty<int>("FundInternalId").HasColumnName("fund_internal_id");
                    j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                });
    }
}