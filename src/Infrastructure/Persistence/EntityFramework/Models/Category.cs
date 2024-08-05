namespace Infrastructure.Persistence.EntityFramework.Models;

public class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public Guid? LimitId { get; set; }

    public Limit? Limit { get; set; }

    public Guid FundId { get; set; }
}