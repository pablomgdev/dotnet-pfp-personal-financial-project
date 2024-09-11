namespace Domain.Transactions.Models;

public class TransactionId : IValueObject<Guid>
{
    public TransactionId(Guid value)
    {
        Value = value;
        Validate();
    }

    public Guid Value { get; set; }

    public bool Validate()
    {
        return true;
    }
}