namespace Domain.Funds.Models;

public class Fund(
    FundId id,
    FundName name,
    FundDescription description,
    FundTotalAmount totalAmount,
    DateTime? createdDate = null)
{
    public FundId Id { get; set; } = id;
    public FundName Name { get; set; } = name;
    public FundDescription Description { get; set; } = description;
    public FundTotalAmount TotalAmount { get; set; } = totalAmount;
    public DateTime? CreatedDate { get; set; } = createdDate;
}