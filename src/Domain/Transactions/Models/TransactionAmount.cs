namespace Domain.Transactions.Models;

public class TransactionAmount : IValueObject
{
    public TransactionAmount(decimal? value)
    {
        Value = value;
        IsValid();
    }

    public decimal? Value { get; set; }

    public bool IsValid()
    {
        return true;
    }
}