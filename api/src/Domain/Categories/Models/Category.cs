using Domain.Limits;

namespace Domain.Categories.Models;

// TODO: use value object instead of primitives and add a constructor with validations.
public class Category
{
    public const int MaxLength = 50;

    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public Limit? Limit { get; set; }

    public Guid FundId { get; set; }
}