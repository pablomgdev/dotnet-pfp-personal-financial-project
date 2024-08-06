namespace Infrastructure.Persistence.EntityFramework.Models;

public class Recurrence
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public RecurrenceType Type { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? UserId { get; set; }
}