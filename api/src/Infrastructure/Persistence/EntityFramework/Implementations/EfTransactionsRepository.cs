using Domain.Transactions.Repositories;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Transaction = Domain.Transactions.Models.Transaction;

namespace Infrastructure.Persistence.EntityFramework.Implementations;

public class EfTransactionsRepository(
    PfpTransactionsApiDatabaseContext context
) : ITransactionsRepository
{
    public async Task<IEnumerable<Transaction>> Get()
    {
        var databaseResults = await context.Transactions
            .Where(t => t.TransactionNotSplitInternalId == null)
            .Include(t => t.Category)
            .Include(t => t.Recurrence)
            .Include(t => t.Recurrence.Type)
            .Include(t => t.SplitTransactions)
            .AsNoTracking()
            .ToListAsync();
        return databaseResults.Select(databaseResult => databaseResult.MapToDomainModel());
    }
}