namespace Infrastructure.Persistence.EntityFramework.Models;

public class Transaction
{
    public Guid Id { get; set; }

    // TODO: this must be not null
    public int? InternalId { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public bool IsSplit { get; set; }

    // TODO: make this FK to transactions table.
    public int? TransactionNotSplitInternalId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    // TODO: see if this relation is like this. It sounds me that one transactions has only one recurrence.
    public virtual ICollection<Recurrence> Recurrences { get; set; } = new List<Recurrence>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}