namespace Contracts.Transactions;

public class Transaction
{
    public Guid Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public bool? IsSplit { get; set; }

    public int? TransactionNotSplitInternalId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }
}