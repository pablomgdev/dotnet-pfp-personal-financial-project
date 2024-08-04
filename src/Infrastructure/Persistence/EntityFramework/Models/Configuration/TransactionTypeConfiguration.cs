using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Models.Configuration;

public class TransactionTypeConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(e => e.Id).HasName("transactions_pkey");

        builder.ToTable("transactions");

        builder.HasIndex(e => e.InternalId, "transactions_internal_id_key").IsUnique();

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.Amount).HasColumnName("amount");
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
        builder.Property(e => e.IsSplit)
            .HasColumnType("boolean")
            .HasColumnName("is_split");
        builder.Property(e => e.TransactionNotSplitInternalId)
            .HasColumnType("int")
            .HasColumnName("transaction_not_split_internal_id");
        builder.Property(e => e.UpdatedDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_date");
        builder.Property(e => e.UserId).HasColumnName("user_id");

        builder.HasMany(d => d.Categories).WithMany(p => p.TransactionInternals)
            .UsingEntity<Dictionary<string, object>>(
                "TransactionsCategory",
                r => r.HasOne<Category>().WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__transactions_categories__category_id__categories"),
                l => l.HasOne<Transaction>().WithMany()
                    .HasPrincipalKey("InternalId")
                    .HasForeignKey("TransactionInternalId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__transactions_categories__transaction_internal_id__transacti"),
                j =>
                {
                    j.HasKey("TransactionInternalId", "CategoryId").HasName("transactions_categories_pkey");
                    j.ToTable("transactions_categories");
                    j.IndexerProperty<int>("TransactionInternalId").HasColumnName("transaction_internal_id");
                    j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                });
    }
}