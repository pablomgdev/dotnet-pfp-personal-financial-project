namespace Infrastructure.Persistence.EntityFramework.Models;

public class Transaction
{
    public Guid Id { get; set; }

    public int InternalId { get; set; }

    public decimal Amount { get; set; }

    public string? Description { get; set; }

    public int? RecurrenceId { get; set; }

    public Recurrence Recurrence { get; set; }

    public bool IsSplit { get; set; }

    public int? TransactionNotSplitInternalId { get; set; }

    public virtual ICollection<Transaction> SplitTransactions { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
}