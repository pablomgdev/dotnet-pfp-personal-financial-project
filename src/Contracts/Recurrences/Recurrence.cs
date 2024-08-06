namespace Contracts.Recurrences;

public class Recurrence
{
    public int? Id { get; set; }

    public RecurrenceType? Type { get; set; }

    // TODO: add reference date to use the type for calculations.
}