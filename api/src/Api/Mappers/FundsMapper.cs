using Contracts.Funds;

namespace Api.Mappers;

public static class FundsMapper
{
    public static Fund? MapToDto(this Domain.Funds.Models.Fund? domainModel)
    {
        if (domainModel is null) return null;
        return new Fund
        {
            Id = domainModel.Id.Value,
            Name = domainModel.Name.Value,
            Description = domainModel.Description.Value,
            TotalAmount = domainModel.TotalAmount.Value,
            CreatedDate = domainModel.CreatedDate
        };
    }
}