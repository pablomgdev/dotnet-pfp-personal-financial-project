using Domain.Transactions.Models;

namespace Domain.Transactions.Repositories;

public interface ITransactionsRepository
{
    Task<IEnumerable<Transaction>> Get();
}