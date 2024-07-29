using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.EntityFramework.Models;

public partial class PfpTransactionsApiDatabaseContext : DbContext
{
    public PfpTransactionsApiDatabaseContext()
    {
    }

    public PfpTransactionsApiDatabaseContext(DbContextOptions<PfpTransactionsApiDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<Limit> Limits { get; set; }

    public virtual DbSet<Recurrence> Recurrences { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    // TODO: save connection string in a configuration file.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=pfp-transactions-api-database;Username=postgres;Password=postgres;");
    }

    // TODO: refactor OnModelCreating method by using IEntityTypeConfiguration interface for each entity.
    //  see: https://learn.microsoft.com/en-us/ef/core/modeling/#grouping-configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Name, "categories_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_date");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("bit(1)")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Fund>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("funds_pkey");

            entity.ToTable("funds");

            entity.HasIndex(e => e.InternalId, "funds_internal_id_key").IsUnique();

            entity.HasIndex(e => e.Name, "funds_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.InternalId)
                .IsRequired()
                .HasColumnName("internal_id");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("bit(1)")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasMany(d => d.Categories).WithMany(p => p.FundInternals)
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
        });

        modelBuilder.Entity<Limit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("limits_pkey");

            entity.ToTable("limits");

            entity.HasIndex(e => e.InternalId, "limits_internal_id_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_date");
            entity.Property(e => e.InternalId).HasColumnName("internal_id");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("bit(1)")
                .HasColumnName("is_deleted");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Limits)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk__limits__category_id__categories");
        });

        modelBuilder.Entity<Recurrence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recurrences_pkey");

            entity.ToTable("recurrences");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_date");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("bit(1)")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.TransactionInternalId).HasColumnName("transaction_internal_id");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.TransactionInternal).WithMany(p => p.Recurrences)
                .HasPrincipalKey(p => p.InternalId)
                .HasForeignKey(d => d.TransactionInternalId)
                .HasConstraintName("fk__recurrences__transaction_internal_id__transaction");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.HasIndex(e => e.InternalId, "transactions_internal_id_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("deleted_date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.InternalId)
                .IsRequired()
                .HasColumnName("internal_id");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("bit(1)")
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsSplit)
                .HasColumnType("bit(1)")
                .HasColumnName("is_split");
            entity.Property(e => e.TransactionNotSplitInternalId)
                .HasColumnType("bit(1)")
                .HasColumnName("transaction_not_split_internal_id");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasMany(d => d.Categories).WithMany(p => p.TransactionInternals)
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}