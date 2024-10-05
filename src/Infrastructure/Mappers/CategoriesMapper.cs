using Domain.Categories.Models;

namespace Infrastructure.Mappers;

public static class CategoriesMapper
{
    public static Category? MapToDomainModel(
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

    public static Persistence.EntityFramework.Models.Category? MapToInfrastructureModel(
        this Category? domainModel)
    {
        if (domainModel is null) return null;
        return new Persistence.EntityFramework.Models.Category
        {
            Id = domainModel.Id,
            Name = domainModel.Name,
            LimitId = domainModel.Limit?.Id,
            Limit = domainModel.Limit?.MapToInfrastructureModel(),
            FundId = domainModel.FundId,
            CreatedDate = domainModel.CreatedDate,
            UpdatedDate = domainModel.UpdatedDate,
            DeletedDate = domainModel.DeletedDate,
            IsDeleted = domainModel.IsDeleted,
            UserId = domainModel.UserId
        };
    }
}