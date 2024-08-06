using Contracts.Recurrences;

namespace Api.Mappers;

public static class RecurrencesMapper
{
    public static Recurrence? MapToDto(this Domain.Recurrences.Recurrence? domainRecurrence)
    {
        if (domainRecurrence is null) return null;
        return new Recurrence
        {
            Id = domainRecurrence?.Id,
            Type = domainRecurrence?.Type?.MapToDto()
        };
    }
}