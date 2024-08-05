using Domain.Categories;

namespace Infrastructure.Mappers;

public static class CategoriesMapper
{
    public static Category MapToDomainModel(
        this Persistence.EntityFramework.Models.Category persistenceCategoryModel)
    {
        return new Category
        {
            Id = persistenceCategoryModel.Id,
            CreatedDate = persistenceCategoryModel.CreatedDate,
            UpdatedDate = persistenceCategoryModel.UpdatedDate,
            IsDeleted = persistenceCategoryModel.IsDeleted,
            DeletedDate = persistenceCategoryModel.DeletedDate,
            UserId = persistenceCategoryModel.UserId,
            Name = persistenceCategoryModel.Name,
            FundId = persistenceCategoryModel.FundId,
            Limit = persistenceCategoryModel.Limit?.MapToDomainModel()
        };
    }
}