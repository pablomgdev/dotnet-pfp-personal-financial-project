namespace Domain.User.Models;

// TODO: as this class is used in other entities it should be in a shared folder.
public class UserId : IValueObject
{
    public UserId(Guid? value)
    {
        Value = value;
        IsValid();
    }

    public Guid? Value { get; set; }

    public bool IsValid()
    {
        return true;
    }
}