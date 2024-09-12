using Domain.Funds.Models;

namespace Infrastructure.Mappers;

public static class FundsMapper
{
    public static Fund? MapToDomainModel(
        this Persistence.EntityFramework.Models.Fund? persistenceModel)
    {
        if (persistenceModel is null) return null;
        return new Fund(
            new FundId(persistenceModel.Id),
            new FundName(persistenceModel.Name ?? string.Empty),
            new FundDescription(persistenceModel.Description ?? string.Empty),
            new FundTotalAmount(persistenceModel.TotalAmount ?? 0),
            persistenceModel.CreatedDate
        );
    }

    public static Persistence.EntityFramework.Models.Fund MapToInfrastructureModel(
        this Fund domainModel)
    {
        return new Persistence.EntityFramework.Models.Fund
        {
            Id = domainModel.Id.Value,
            Name = domainModel.Name.Value,
            Description = domainModel.Description.Value,
            TotalAmount = domainModel.TotalAmount.Value,
            CreatedDate = domainModel.CreatedDate,
            InternalId = null,
            Categories = [],
            UpdatedDate = null,
            DeletedDate = null,
            IsDeleted = false,
            UserId = null
        };
    }
}