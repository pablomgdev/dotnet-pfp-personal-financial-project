using Contracts.Transactions;

namespace Api.Mappers;

public static class TransactionsMapper
{
    public static Transaction MapToDto(this Domain.Transactions.Models.Transaction domainTransaction)
    {
        // TODO: see recurrences and categories values...
        return new Transaction
        {
            Id = domainTransaction.Id.Value,
            Description = domainTransaction.Description.Value,
            Amount = domainTransaction.Amount.Value,
            IsSplit = domainTransaction.IsSplit,
            CreatedDate = domainTransaction.CreatedDate,
            UpdatedDate = domainTransaction.UpdatedDate,
            IsDeleted = domainTransaction.IsDeleted,
            DeletedDate = domainTransaction.DeletedDate,
            UserId = domainTransaction.UserId.Value,
            SplitTransactions = domainTransaction.SplitTransactions
                ?.Select(splitTransaction => splitTransaction.MapToDto())
        };
    }
}