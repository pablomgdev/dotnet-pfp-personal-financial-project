namespace Domain.Transactions.Models;

public class Description : IValueObject
{
    public Description(string? value)
    {
        Value = value;
        if (!IsValid()) throw new Exception("Description cannot have more than 255 characters");
    }

    public string? Value { get; set; }

    public bool IsValid()
    {
        return Value?.Length <= 255;
    }
}