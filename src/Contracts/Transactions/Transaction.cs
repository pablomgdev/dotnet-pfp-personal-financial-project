namespace Contracts.Transactions;

public class Transaction
{
    public Guid Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public bool? IsSplit { get; set; }

    public bool? TransactionNotSplitInternalId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    // TODO: add missing properties as nullable to be able of reduce the json response size.
    // public virtual ICollection<Recurrence> Recurrences { get; set; } = new List<Recurrence>();
    //
    // public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}