using Domain.Recurrences;

namespace Infrastructure.Mappers;

public static class RecurrenceTypesMapper
{
    public static RecurrenceType? MapToDomainModel(
        this Persistence.EntityFramework.Models.RecurrenceType persistenceRecurrenceTypeModel)
    {
        return new RecurrenceType
        {
            Id = persistenceRecurrenceTypeModel.Id,
            Name = persistenceRecurrenceTypeModel.Name
        };
    }
}