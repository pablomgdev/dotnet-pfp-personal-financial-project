using Domain.Categories.Models;

namespace Domain.Limits;

/// <summary>
///     Amount of money that can be spent in a <see cref="Category" /> within a period of time specified.
///     <br />
///     For now, it is only available "per month" limit period so there is no property to specify it.
/// </summary>
public class Limit
{
    public Guid Id { get; set; }

    public int? InternalId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }
}