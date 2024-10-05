namespace Domain.Categories.Exceptions;

public class EmptyFundInCategoryException(string message = "a fund must be specified") : Exception(message)
{
}