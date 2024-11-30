using Contracts.Categories;
using Contracts.Recurrences;

namespace Contracts.Transactions;

public class Transaction
{
    public Guid? Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public bool? IsSplit { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public IEnumerable<Transaction?>? SplitTransactions { get; set; }

    public Recurrence? Recurrence { get; set; }

    public Category? Category { get; set; }
}