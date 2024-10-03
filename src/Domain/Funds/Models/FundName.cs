using Domain.Funds.Exceptions;

namespace Domain.Funds.Models;

public class FundName : IValueObject<string>
{
    private const int MaxLength = 50;

    public FundName(string name)
    {
        Value = name;
        Validate();
    }

    public string Value { get; set; }

    public bool Validate()
    {
        if (string.IsNullOrEmpty(Value))
            throw new EmptyFundNameException();
        if (Value.Length >= MaxLength)
            throw new FundNameLengthException(MaxLength);
        return true;
    }
}