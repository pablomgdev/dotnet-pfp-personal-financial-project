namespace Domain.Categories.Exceptions;

public class CategoryNameMaxLengthException(string message = "category name length is not valid")
    : Exception(message)
{
    public CategoryNameMaxLengthException(int maxLength) : this(
        $"category name cannot be more than {maxLength} characters")
    {
    }
}