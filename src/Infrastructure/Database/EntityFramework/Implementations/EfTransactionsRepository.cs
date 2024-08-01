using Domain.Transactions.Models;
using Domain.Transactions.Repositories;
using Domain.User;
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
            new Amount(result.Amount),
            new Description(result.Description),
            result.IsSplit != null && result.IsSplit.Get(0),
            result.TransactionNotSplitInternalId != null && result.TransactionNotSplitInternalId.Get(0),
            result.CreatedDate,
            result.UpdatedDate,
            result.IsDeleted != null && result.IsDeleted.Get(0),
            result.DeletedDate,
            new UserId(result.UserId)));
    }
}