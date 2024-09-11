using Domain.Funds.Exceptions;

namespace Domain.Funds.Models;

public class FundName : IValueObject
{
    private const int MaxValueLength = 50;

    public FundName(string name)
    {
        Value = name;
        if (!IsValid()) throw new InvalidFundNameLength($"Name cannot be more than {MaxValueLength} characters");
    }

    public string Value { get; set; }

    public bool IsValid()
    {
        // TODO: check also if this is null or empty.
        return Value.Length < MaxValueLength;
    }
}