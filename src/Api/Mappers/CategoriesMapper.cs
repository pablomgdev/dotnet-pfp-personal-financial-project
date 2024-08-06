using Contracts.Categories;

namespace Api.Mappers;

public static class CategoriesMapper
{
    public static Category MapToDto(this Domain.Categories.Category? domainCategory)
    {
        return new Category
        {
            Id = domainCategory.Id,
            Name = domainCategory.Name,
            CreatedDate = domainCategory.CreatedDate,
            UpdatedDate = domainCategory.UpdatedDate,
            Limit = domainCategory.Limit?.MapToDto(),
            FundId = domainCategory.FundId
        };
    }
}