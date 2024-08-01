using Domain.User;

namespace Domain.Transactions.Models;

public class Transaction(
    TransactionId id,
    Amount amount,
    Description description,
    bool isSplit,
    bool transactionNotSplitInternalId,
    DateTime? createdDate,
    DateTime? updatedDate,
    bool isDeleted,
    DateTime? deletedDate,
    UserId userId)
{
    public TransactionId Id { get; set; } = id;

    public Amount Amount { get; set; } = amount;

    public Description Description { get; set; } = description;

    public bool? IsSplit { get; set; } = isSplit;

    public bool? TransactionNotSplitInternalId { get; set; } = transactionNotSplitInternalId;

    public DateTime? CreatedDate { get; set; } = createdDate;

    public DateTime? UpdatedDate { get; set; } = updatedDate;

    public bool? IsDeleted { get; set; } = isDeleted;

    public DateTime? DeletedDate { get; set; } = deletedDate;

    public UserId UserId { get; set; } = userId;
}