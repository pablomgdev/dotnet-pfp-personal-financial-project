using Domain.User.Models;

namespace Domain.Transactions.Models;

public class Transaction(
    TransactionId id,
    int? InternalId,
    TransactionAmount transactionAmount,
    TransactionDescription transactionDescription,
    bool isSplit,
    int? transactionNotSplitInternalId,
    DateTime? CreatedDate,
    DateTime? UpdatedDate,
    bool IsDeleted,
    DateTime? DeletedDate,
    UserId userId)
{
    public TransactionId Id { get; set; } = id;

    public int? InternalId { get; set; }

    public TransactionAmount TransactionAmount { get; set; } = transactionAmount;

    public TransactionDescription TransactionDescription { get; set; } = transactionDescription;

    public bool IsSplit { get; set; } = isSplit;

    public int? TransactionNotSplitInternalId { get; set; } = transactionNotSplitInternalId;

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public UserId UserId { get; set; } = userId;

    // TODO: see recurrences and categories properties.
}