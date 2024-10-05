using Domain.Categories.Models;

namespace Domain.Categories.Repositories;

public interface ICategoriesRepository
{
    Task<Category> Create(Category category);
}