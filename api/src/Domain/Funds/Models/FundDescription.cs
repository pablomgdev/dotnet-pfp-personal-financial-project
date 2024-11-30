using Domain.Funds.Exceptions;

namespace Domain.Funds.Models;

public class FundDescription : IValueObject<string>
{
    private const int MaxValueLength = 255;

    public FundDescription(string description)
    {
        Value = description;
        Validate();
    }

    public string Value { get; set; }

    public bool Validate()
    {
        if (string.IsNullOrEmpty(Value))
            throw new EmptyFundDescriptionException();
        if (Value.Length >= MaxValueLength)
            throw new FundDescriptionLengthException(MaxValueLength);
        return true;
    }
}