namespace Contracts.Transactions;

public class Transaction
{
    public Guid Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public bool? IsSplit { get; set; }

    // TODO: remove this property as it is used only in database.
    public int? TransactionNotSplitInternalId { get; set; }

    public Guid? UserId { get; set; }
}