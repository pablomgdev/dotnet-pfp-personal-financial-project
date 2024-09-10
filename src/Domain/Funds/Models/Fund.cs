namespace Domain.Funds.Models;

// TODO: add missing properties
public class Fund(FundId id, FundName name, FundDescription description)
{
    public FundId Id { get; set; } = id;
    public FundName Name { get; set; } = name;
    public FundDescription Description { get; set; } = description;
}