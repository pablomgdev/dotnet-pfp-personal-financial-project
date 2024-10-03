namespace Domain.Funds.Models;

public class FundId : IValueObject<Guid>
{
    public FundId(Guid id)
    {
        Value = id;
    }

    public Guid Value { get; set; }

    public bool Validate()
    {
        return true;
    }
}