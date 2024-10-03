namespace Domain;

public interface IValueObject<T>
{
    public T Value { get; set; }
    public bool Validate();
}