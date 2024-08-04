using Domain.Transactions.Models;
using Domain.Transactions.Repositories;
using Domain.User.Models;
using Microsoft.EntityFrameworkCore;
using Transaction = Domain.Transactions.Models.Transaction;

namespace Infrastructure.Persistence.EntityFramework.Implementations;

public class EfTransactionsRepository(PfpTransactionsApiDatabaseContext context) : ITransactionsRepository
{
    public async Task<IEnumerable<Transaction>> Get()
    {
        // TODO: add automapper to use it here.
        var dbResult = await context.Transactions.AsNoTracking().ToListAsync();
        return dbResult.Select(result => new Transaction(
            new TransactionId(result.Id),
            new TransactionAmount(result.Amount),
            new TransactionDescription(result.Description),
            result.IsSplit,
            result.TransactionNotSplitInternalId,
            new UserId(result.UserId)));
    }
}