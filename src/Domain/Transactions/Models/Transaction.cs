using Domain.Categories;
using Domain.Recurrences;
using Domain.User.Models;

namespace Domain.Transactions.Models;

public class Transaction(
    TransactionId id,
    TransactionAmount amount,
    TransactionDescription description,
    bool isSplit,
    IEnumerable<Transaction>? splitTransactions,
    DateTime? createdDate,
    DateTime? updatedDate,
    bool isDeleted,
    DateTime? deletedDate,
    UserId userId,
    Recurrence? recurrence,
    Category? category)
{
    public TransactionId Id { get; set; } = id;
    public TransactionAmount Amount { get; set; } = amount;
    public TransactionDescription Description { get; set; } = description;
    public bool IsSplit { get; set; } = isSplit;

    /// <summary>
    ///     If the transaction has been split, this property will have all the remaining transactions generated.
    /// </summary>
    public IEnumerable<Transaction>? SplitTransactions { get; set; } = splitTransactions;

    public DateTime? CreatedDate { get; set; } = createdDate;
    public DateTime? UpdatedDate { get; set; } = updatedDate;
    public bool IsDeleted { get; set; } = isDeleted;
    public DateTime? DeletedDate { get; set; } = deletedDate;

    public UserId UserId { get; set; } = userId;

    public Recurrence? Recurrence { get; set; } = recurrence;

    public Category? Category { get; set; } = category;
}