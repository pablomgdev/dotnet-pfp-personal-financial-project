namespace Domain.Funds.Models;

public class FundId : IValueObject
{
    public FundId(Guid id)
    {
        Value = id;
    }

    public Guid Value { get; set; }

    public bool IsValid()
    {
        return true;
    }
}