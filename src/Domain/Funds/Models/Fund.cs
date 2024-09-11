using Domain.User.Models;

namespace Domain.Funds.Models;

public class Fund(
    FundId id,
    FundName name,
    FundDescription description,
    FundTotalAmount totalAmount,
    bool isDeleted = false,
    DateTime? createdDate = null,
    DateTime? updatedDate = null,
    DateTime? deletedDate = null,
    UserId? userId = null)
{
    public FundId Id { get; set; } = id;
    public FundName Name { get; set; } = name;
    public FundDescription Description { get; set; } = description;
    public FundTotalAmount TotalAmount { get; set; } = totalAmount;
    public DateTime? CreatedDate { get; set; } = createdDate;
    public DateTime? UpdatedDate { get; set; } = updatedDate;
    public bool IsDeleted { get; set; } = isDeleted;
    public DateTime? DeletedDate { get; set; } = deletedDate;
    public UserId UserId { get; set; } = userId;
}