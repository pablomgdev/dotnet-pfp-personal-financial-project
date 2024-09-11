using Domain.Funds.Exceptions;

namespace Domain.Funds.Models;

public class FundDescription : IValueObject
{
    private const int MaxValueLength = 255;

    public FundDescription(string description)
    {
        Value = description;
        if (!IsValid()) throw new InvalidFundDescriptionLength($"Name cannot be more than {MaxValueLength} characters");
    }

    public string Value { get; set; }

    public bool IsValid()
    {
        // TODO: check also if this is null or empty.
        return Value.Length < MaxValueLength;
    }
}