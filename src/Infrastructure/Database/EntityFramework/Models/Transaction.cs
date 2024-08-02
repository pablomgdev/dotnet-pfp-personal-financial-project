namespace Infrastructure.Database.EntityFramework.Models;

public class Transaction
{
    public Guid Id { get; set; }

    public int? InternalId { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public bool IsSplit { get; set; }

    public int? TransactionNotSplitInternalId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<Recurrence> Recurrences { get; set; } = new List<Recurrence>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}