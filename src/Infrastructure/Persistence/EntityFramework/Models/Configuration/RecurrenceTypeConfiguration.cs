using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Models.Configuration;

public class RecurrenceTypeConfiguration : IEntityTypeConfiguration<Recurrence>
{
    public void Configure(EntityTypeBuilder<Recurrence> builder)
    {
        builder.HasKey(e => e.Id).HasName("recurrences_pkey");

        builder.ToTable("recurrences");

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