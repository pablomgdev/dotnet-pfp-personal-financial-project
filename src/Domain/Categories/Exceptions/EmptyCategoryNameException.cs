namespace Domain.Categories.Exceptions;

public class EmptyCategoryNameException(string message = "category name is mandatory") : Exception(message)
{
}