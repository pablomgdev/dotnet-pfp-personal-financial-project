using Domain.User.Models;

namespace Domain.Transactions.Models;

public class Transaction(
    TransactionId id,
    TransactionAmount transactionAmount,
    TransactionDescription transactionDescription,
    bool isSplit,
    int? transactionNotSplitInternalId,
    DateTime? createdDate,
    DateTime? updatedDate,
    bool isDeleted,
    DateTime? deletedDate,
    UserId userId)
{
    public TransactionId Id { get; set; } = id;

    public TransactionAmount TransactionAmount { get; set; } = transactionAmount;

    public TransactionDescription TransactionDescription { get; set; } = transactionDescription;

    public bool? IsSplit { get; set; } = isSplit;

    public int? TransactionNotSplitInternalId { get; set; } = transactionNotSplitInternalId;

    public DateTime? CreatedDate { get; set; } = createdDate;

    public DateTime? UpdatedDate { get; set; } = updatedDate;

    public bool? IsDeleted { get; set; } = isDeleted;

    public DateTime? DeletedDate { get; set; } = deletedDate;

    public UserId UserId { get; set; } = userId;
}