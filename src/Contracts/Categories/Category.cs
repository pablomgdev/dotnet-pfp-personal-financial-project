using Contracts.Limits;

namespace Contracts.Categories;

public class Category
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Limit? Limit { get; set; }

    public Guid FundId { get; set; }
}