namespace Domain.User.Models;

// TODO: as this class is used in other entities it should be in a shared folder.
public class UserId : IValueObject<Guid?>
{
    public UserId(Guid? value)
    {
        Value = value;
        Validate();
    }

    public Guid? Value { get; set; }

    public bool Validate()
    {
        return true;
    }
}