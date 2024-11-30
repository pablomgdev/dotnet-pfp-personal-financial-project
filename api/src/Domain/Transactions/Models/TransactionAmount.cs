namespace Domain.Transactions.Models;

public class TransactionAmount : IValueObject<decimal?>
{
    public TransactionAmount(decimal? value)
    {
        Value = value;
        Validate();
    }

    public decimal? Value { get; set; }

    public bool Validate()
    {
        return true;
    }
}