using Infrastructure.Persistence.EntityFramework.Models;
using Infrastructure.Persistence.EntityFramework.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework;

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
        base.OnConfiguring(optionsBuilder);
        // Note: use as Host name the docker compose service name. If using dotnet ef command, change it to localhost.
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=pfp-transactions-api-database;Username=postgres;Password=postgres;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryTypeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FundTypeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LimitTypeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecurrenceTypeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransactionTypeConfiguration).Assembly);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}