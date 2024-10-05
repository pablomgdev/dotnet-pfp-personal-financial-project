using Domain.Categories.Models;
using Domain.Categories.Repositories;

namespace Application.Categories;

public class CategoriesCreator(
    ICategoriesRepository _categoriesRepository
)
{
    public async Task<Category> Invoke(Guid categoryFundId, string categoryName, decimal categoryLimit)
    {
        throw new NotImplementedException();
    }
}