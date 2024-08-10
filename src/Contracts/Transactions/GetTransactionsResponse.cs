namespace Contracts.Transactions;

public record GetTransactionsResponse(
    List<Transaction> Transactions
);