namespace Contracts.Categories;

public record CreateCategoryRequest(
    Guid? FundId,
    string? Name
);