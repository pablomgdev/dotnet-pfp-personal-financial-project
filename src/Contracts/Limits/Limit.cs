namespace Contracts.Limits;

public class Limit
{
    public Guid? Id { get; set; }

    public int? InternalId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}