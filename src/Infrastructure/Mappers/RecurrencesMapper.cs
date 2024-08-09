using Domain.Recurrences;

namespace Infrastructure.Mappers;

public static class RecurrencesMapper
{
    public static Recurrence? MapToDomainModel(
        this Persistence.EntityFramework.Models.Recurrence? persistenceRecurrenceModel)
    {
        if (persistenceRecurrenceModel is null) return null;
        return new Recurrence
        {
            Id = persistenceRecurrenceModel.Id,
            CreatedDate = persistenceRecurrenceModel.CreatedDate,
            UpdatedDate = persistenceRecurrenceModel.UpdatedDate,
            IsDeleted = persistenceRecurrenceModel.IsDeleted,
            DeletedDate = persistenceRecurrenceModel.DeletedDate,
            UserId = persistenceRecurrenceModel.UserId,
            Type = persistenceRecurrenceModel.Type.MapToDomainModel()
        };
    }
}