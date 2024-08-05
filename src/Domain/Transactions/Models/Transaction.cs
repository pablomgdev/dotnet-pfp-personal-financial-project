using Domain.Categories;
using Domain.Recurrences;
using Domain.User.Models;

namespace Domain.Transactions.Models;

public class Transaction
{
    public Transaction(
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
        Recurrence recurrence,
        Category category)
    {
        Id = id;
        Amount = amount;
        Description = description;
        IsSplit = isSplit;
        SplitTransactions = splitTransactions;
        UserId = userId;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        IsDeleted = isDeleted;
        DeletedDate = deletedDate;
        UserId = userId;
        Recurrence = recurrence;
        Category = category;
    }

    public TransactionId Id { get; set; }
    public TransactionAmount Amount { get; set; }
    public TransactionDescription Description { get; set; }
    public bool IsSplit { get; set; }

    /// <summary>
    ///     If the transaction has been split, this property will have all the remaining transactions generated.
    /// </summary>
    public IEnumerable<Transaction>? SplitTransactions { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }

    public UserId UserId { get; set; }

    public Recurrence Recurrence { get; set; }

    public Category Category { get; set; }
}