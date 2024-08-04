using Domain.Transactions.Repositories;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Transaction = Domain.Transactions.Models.Transaction;

namespace Infrastructure.Persistence.EntityFramework.Implementations;

public class EfTransactionsRepository(PfpTransactionsApiDatabaseContext context) : ITransactionsRepository
{
    public async Task<IEnumerable<Transaction>> Get()
    {
        var dbResult = await context.Transactions.AsNoTracking().ToListAsync();
        return dbResult.Select(databaseResult => databaseResult.MapToDomainModel());
    }
}