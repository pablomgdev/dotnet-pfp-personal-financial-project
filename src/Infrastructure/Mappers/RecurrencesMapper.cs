using Domain.Recurrences;

namespace Infrastructure.Mappers;

public static class RecurrencesMapper
{
    public static Recurrence MapToDomainModel(
        this Persistence.EntityFramework.Models.Recurrence persistenceRecurrenceModel)
    {
        return new Recurrence
        {
            Id = persistenceRecurrenceModel.Id,
            CreatedDate = persistenceRecurrenceModel.CreatedDate,
            UpdatedDate = persistenceRecurrenceModel.UpdatedDate,
            IsDeleted = persistenceRecurrenceModel.IsDeleted,
            DeletedDate = persistenceRecurrenceModel.DeletedDate,
            UserId = persistenceRecurrenceModel.UserId,
            Name = persistenceRecurrenceModel.Name
        };
    }
}