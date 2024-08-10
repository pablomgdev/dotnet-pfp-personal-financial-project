using Domain.Transactions.Models;
using Domain.Transactions.Repositories;

namespace Application.Transactions.Get;

public class TransactionsGetter(ITransactionsRepository transactionsRepository)
{
    public async Task<IEnumerable<Transaction>> Get()
    {
        return await transactionsRepository.Get();
    }
}