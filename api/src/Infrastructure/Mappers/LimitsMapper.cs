using Domain.Limits;

namespace Infrastructure.Mappers;

public static class LimitsMapper
{
    public static Limit MapToDomainModel(
        this Persistence.EntityFramework.Models.Limit persistenceLimitModel)
    {
        return new Limit
        {
            Id = persistenceLimitModel.Id,
            CreatedDate = persistenceLimitModel.CreatedDate,
            UpdatedDate = persistenceLimitModel.UpdatedDate,
            IsDeleted = persistenceLimitModel.IsDeleted,
            DeletedDate = persistenceLimitModel.DeletedDate,
            UserId = persistenceLimitModel.UserId,
            Amount = persistenceLimitModel.Amount,
            InternalId = persistenceLimitModel.InternalId
        };
    }

    public static Persistence.EntityFramework.Models.Limit MapToInfrastructureModel(
        this Limit domainModel)
    {
        return new Persistence.EntityFramework.Models.Limit
        {
            Id = domainModel.Id,
            InternalId = domainModel?.InternalId,
            Amount = domainModel?.Amount,
            CreatedDate = domainModel?.CreatedDate,
            UpdatedDate = domainModel?.UpdatedDate,
            IsDeleted = domainModel?.IsDeleted,
            DeletedDate = domainModel?.DeletedDate,
            UserId = domainModel?.UserId
        };
    }
}