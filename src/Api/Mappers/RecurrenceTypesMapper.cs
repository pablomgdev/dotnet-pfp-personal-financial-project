using Contracts.Recurrences;

namespace Api.Mappers;

public static class RecurrenceTypesMapper
{
    public static RecurrenceType? MapToDto(this Domain.Recurrences.RecurrenceType? domainRecurrenceType)
    {
        if (domainRecurrenceType is null) return null;
        return new RecurrenceType
        {
            Id = domainRecurrenceType?.Id,
            Name = domainRecurrenceType?.Name
        };
    }
}