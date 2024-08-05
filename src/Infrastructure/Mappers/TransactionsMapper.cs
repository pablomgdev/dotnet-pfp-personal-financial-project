using Domain.Transactions.Models;
using Domain.User.Models;

namespace Infrastructure.Mappers;

public static class TransactionsMapper
{
    public static Transaction MapToDomainModel(
        this Persistence.EntityFramework.Models.Transaction persistenceTransactionModel)
    {
        return new Transaction(
            new TransactionId(persistenceTransactionModel.Id),
            new TransactionAmount(persistenceTransactionModel.Amount),
            new TransactionDescription(persistenceTransactionModel.Description),
            persistenceTransactionModel.IsSplit,
            // TODO see this. Maybe is a missing relation
            null,
            persistenceTransactionModel.CreatedDate,
            persistenceTransactionModel.UpdatedDate,
            persistenceTransactionModel.IsDeleted,
            persistenceTransactionModel.DeletedDate,
            new UserId(persistenceTransactionModel.UserId),
            persistenceTransactionModel.Recurrence.MapToDomainModel(),
            persistenceTransactionModel.Category.MapToDomainModel()
        );
    }
}