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
            InternalId = domainTransaction.InternalId,
            Description = domainTransaction.TransactionDescription.Value,
            Amount = domainTransaction.TransactionAmount.Value,
            IsSplit = domainTransaction.IsSplit,
            TransactionNotSplitInternalId = domainTransaction.TransactionNotSplitInternalId,
            CreatedDate = domainTransaction.CreatedDate,
            UpdatedDate = domainTransaction.UpdatedDate,
            IsDeleted = domainTransaction.IsDeleted,
            DeletedDate = domainTransaction.DeletedDate,
            UserId = domainTransaction.UserId.Value
        };
    }
}