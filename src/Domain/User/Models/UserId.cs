namespace Domain.User.Models;

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