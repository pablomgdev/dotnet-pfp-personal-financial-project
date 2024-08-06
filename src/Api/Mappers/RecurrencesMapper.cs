using Contracts.Recurrences;

namespace Api.Mappers;

public static class RecurrencesMapper
{
    public static Recurrence MapToDto(this Domain.Recurrences.Recurrence? domainRecurrence)
    {
        return new Recurrence
        {
            Id = domainRecurrence.Id,
            Name = domainRecurrence.Name
        };
    }
}