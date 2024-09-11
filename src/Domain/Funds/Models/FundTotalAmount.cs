namespace Domain.Funds.Models;

public class FundTotalAmount : IValueObject
{
    public FundTotalAmount(decimal totalAmount)
    {
        TotalAmount = totalAmount;
    }

    public decimal TotalAmount { get; set; }

    public bool IsValid()
    {
        return true;
    }
}