using System.Diagnostics;
using Domain.Transactions.Repositories;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Transaction = Domain.Transactions.Models.Transaction;

namespace Infrastructure.Persistence.EntityFramework.Implementations;

public class EfTransactionsRepository(
    PfpTransactionsApiDatabaseContext context,
    ILogger<EfTransactionsRepository> logger = null
) : ITransactionsRepository
{
    public async Task<IEnumerable<Transaction>> Get()
    {
        var beforeGetTransactionsTimestamp = Stopwatch.GetTimestamp();
        var databaseResults = await context.Transactions
            .Include(x => x.Category)
            .Include(x => x.Recurrence)
            .Include(x => x.Recurrence.Type)
            .AsNoTracking()
            .ToListAsync();
        var afterGetTransactionsTimestamp = Stopwatch.GetTimestamp();
        // logger?.LogInformation(
        //     $"context.Transactions.AsNoTracking().ToListAsync() elapsed time: {Stopwatch.GetElapsedTime(beforeGetTransactionsTimestamp, afterGetTransactionsTimestamp)}");
        return databaseResults.Select(databaseResult => databaseResult.MapToDomainModel());
    }
}