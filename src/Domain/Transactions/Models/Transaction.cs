using Domain.User.Models;

namespace Domain.Transactions.Models;

public class Transaction(
    TransactionId id,
    TransactionAmount transactionAmount,
    TransactionDescription transactionDescription,
    bool isSplit,
    int? transactionNotSplitInternalId,
    UserId userId)
{
    public TransactionId Id { get; set; } = id;

    public TransactionAmount TransactionAmount { get; set; } = transactionAmount;

    public TransactionDescription TransactionDescription { get; set; } = transactionDescription;

    public bool? IsSplit { get; set; } = isSplit;

    public int? TransactionNotSplitInternalId { get; set; } = transactionNotSplitInternalId;

    public UserId UserId { get; set; } = userId;
}