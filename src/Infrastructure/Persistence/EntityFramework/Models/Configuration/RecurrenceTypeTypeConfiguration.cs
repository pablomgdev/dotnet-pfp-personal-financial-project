using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Models.Configuration;

public class RecurrenceTypeTypeConfiguration : IEntityTypeConfiguration<RecurrenceType>
{
    public void Configure(EntityTypeBuilder<RecurrenceType> builder)
    {
        builder.HasKey(e => e.Id).HasName("recurrence_types_pkey");

        builder.ToTable("recurrence_types");

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn();
        builder.Property(e => e.Name)
            .HasColumnName("name");
    }
}