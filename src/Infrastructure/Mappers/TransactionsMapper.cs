using Domain.Transactions.Models;
using Domain.User.Models;

namespace Infrastructure.Mappers;

public static class TransactionsMapper
{
    // Not used for now.
    // public static Transaction MapToPersistenceModel(this Domain.Transactions.Models.Transaction domainTransaction)
    // {
    //     // TODO: see recurrences and categories values...
    //     return new Transaction
    //     {
    //         Id = domainTransaction.Id.Value,
    //         InternalId = domainTransaction.InternalId,
    //         Description = domainTransaction.TransactionDescription.Value,
    //         Amount = domainTransaction.TransactionAmount.Value,
    //         IsSplit = domainTransaction.IsSplit,
    //         TransactionNotSplitInternalId = domainTransaction.TransactionNotSplitInternalId,
    //         CreatedDate = domainTransaction.CreatedDate,
    //         UpdatedDate = domainTransaction.UpdatedDate,
    //         IsDeleted = domainTransaction.IsDeleted,
    //         DeletedDate = domainTransaction.DeletedDate,
    //         UserId = domainTransaction.UserId.Value
    //         // Recurrences = domainTransaction,
    //         // Categories = domainTransaction,
    //     };
    // }

    public static Transaction MapToDomainModel(
        this Persistence.EntityFramework.Models.Transaction persistenceTransactionModel)
    {
        // TODO: see recurrences and categories values...
        return new Transaction
        (
            new TransactionId(persistenceTransactionModel.Id),
            persistenceTransactionModel.InternalId,
            new TransactionAmount(persistenceTransactionModel.Amount),
            new TransactionDescription(persistenceTransactionModel.Description),
            persistenceTransactionModel.IsSplit,
            persistenceTransactionModel.TransactionNotSplitInternalId,
            persistenceTransactionModel.CreatedDate,
            persistenceTransactionModel.UpdatedDate,
            persistenceTransactionModel.IsDeleted,
            persistenceTransactionModel.DeletedDate,
            new UserId(persistenceTransactionModel.UserId)
            // Recurrences = domainTransaction,
            // Categories = domainTransaction,
        );
    }
}