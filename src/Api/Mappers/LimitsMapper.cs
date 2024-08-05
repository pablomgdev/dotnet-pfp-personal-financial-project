using Contracts.Limits;

namespace Api.Mappers;

public static class LimitsMapper
{
    public static Limit MapToDto(this Domain.Limits.Limit domainLimit)
    {
        return new Limit
        {
            Id = domainLimit.Id,
            CreatedDate = domainLimit.CreatedDate,
            UpdatedDate = domainLimit.UpdatedDate,
            Amount = domainLimit.Amount,
            InternalId = domainLimit.InternalId
        };
    }
}