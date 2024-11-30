namespace Domain.Funds.Models;

public class FundTotalAmount : IValueObject<decimal>
{
    public FundTotalAmount(decimal totalAmount)
    {
        Value = totalAmount;
        Validate();
    }

    public decimal Value { get; set; }

    public bool Validate()
    {
        return true;
    }
}