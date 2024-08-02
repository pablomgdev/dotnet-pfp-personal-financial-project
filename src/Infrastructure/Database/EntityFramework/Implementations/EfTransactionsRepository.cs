using Domain.Transactions.Models;
using Domain.Transactions.Repositories;
using Domain.User.Models;
using Infrastructure.Database.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Transaction = Domain.Transactions.Models.Transaction;

namespace Infrastructure.Database.EntityFramework.Implementations;

public class EfTransactionsRepository(PfpTransactionsApiDatabaseContext context) : ITransactionsRepository
{
    public async Task<IEnumerable<Transaction>> Get()
    {
        var dbResult = await context.Transactions.ToListAsync();
        return dbResult.Select(result => new Transaction(
            new TransactionId(result.Id),
            new TransactionAmount(result.Amount),
            new TransactionDescription(result.Description),
            result.IsSplit,
            result.TransactionNotSplitInternalId,
            result.CreatedDate,
            result.UpdatedDate,
            result.IsDeleted,
            result.DeletedDate,
            new UserId(result.UserId)));
    }
}