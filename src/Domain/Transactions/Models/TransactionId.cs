namespace Domain.Transactions.Models;

public class TransactionId : IValueObject
{
    public TransactionId(Guid value)
    {
        Value = value;
        IsValid();
    }

    public Guid Value { get; set; }

    public bool IsValid()
    {
        return true;
    }
}