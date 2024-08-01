namespace Domain.Transactions.Models;

public class Amount : IValueObject
{
    public Amount(decimal? value)
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