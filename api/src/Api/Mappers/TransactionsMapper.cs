using Contracts.Transactions;

namespace Api.Mappers;

public static class TransactionsMapper
{
    public static Transaction MapToDto(this Domain.Transactions.Models.Transaction domainTransaction)
    {
        return new Transaction
        {
            Id = domainTransaction.Id.Value,
            Description = domainTransaction.Description.Value,
            Amount = domainTransaction.Amount.Value,
            IsSplit = domainTransaction.IsSplit,
            CreatedDate = domainTransaction.CreatedDate,
            UpdatedDate = domainTransaction.UpdatedDate,
            SplitTransactions = domainTransaction.SplitTransactions
                ?.Select(splitTransaction => splitTransaction.MapToDto()),
            Recurrence = domainTransaction.Recurrence?.MapToDto(),
            Category = domainTransaction.Category?.MapToDto()
        };
    }
}