using Domain.Transactions.Exceptions;

namespace Domain.Transactions.Models;

public class TransactionDescription : IValueObject<string?>
{
    private const int MaxLength = 255;

    public TransactionDescription(string? value)
    {
        Value = value;
        Validate();
    }

    public string? Value { get; set; }

    public bool Validate()
    {
        if (Value?.Length >= MaxLength)
            throw new TransactionDescriptionLengthException(MaxLength);
        return true;
    }
}