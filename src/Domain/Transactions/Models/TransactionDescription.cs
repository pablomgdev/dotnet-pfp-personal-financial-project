namespace Domain.Transactions.Models;

public class TransactionDescription : IValueObject
{
    public TransactionDescription(string? value)
    {
        Value = value;
        // TODO: add domain exceptions for each one (this would be TransactionDescriptionLengthException).
        if (!IsValid()) throw new Exception("Description cannot have more than 255 characters");
    }

    public string? Value { get; set; }

    public bool IsValid()
    {
        return Value?.Length <= 255;
    }
}