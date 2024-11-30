using Domain.Categories.Models;

namespace Domain.Categories.Exceptions;

public class CategoryAlreadyExistsException(string message = "category already exists") : Exception(message)
{
    public CategoryAlreadyExistsException(int categoryId) : this(
        $"category {categoryId} already exists")
    {
    }
}