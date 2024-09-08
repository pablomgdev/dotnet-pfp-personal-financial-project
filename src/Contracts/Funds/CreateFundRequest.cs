using Contracts.Categories;

namespace Contracts.Funds;

// TODO: check properties added. Remove the ones not needed.
public record CreateFundRequest(
    Guid Id,
    int? InternalId,
    string? Name,
    string? Description,
    decimal? TotalAmount,
    DateTime? CreatedDate,
    DateTime? UpdatedDate,
    bool? IsDeleted,
    DateTime? DeletedDate,
    Guid? UserId,
    ICollection<Category> Categories
);