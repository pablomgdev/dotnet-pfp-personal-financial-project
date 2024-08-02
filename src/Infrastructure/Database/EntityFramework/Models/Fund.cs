namespace Infrastructure.Database.EntityFramework.Models;

public class Fund
{
    public Guid Id { get; set; }

    public int? InternalId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}