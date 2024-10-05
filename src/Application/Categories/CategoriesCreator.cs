using Domain.Categories.Exceptions;
using Domain.Categories.Models;
using Domain.Categories.Repositories;
using Domain.Funds.Repositories;
using Domain.Funds.Services;

namespace Application.Categories;

public class CategoriesCreator
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly FundFinder _fundFinder;

    public CategoriesCreator(
        ICategoriesRepository categoriesRepository,
        IFundsRepository fundsRepository
    )
    {
        _categoriesRepository = categoriesRepository;
        var fundSearcher = new FundSearcher(fundsRepository);
        _fundFinder = new FundFinder(fundSearcher);
    }

    public async Task<Category> Invoke(Guid? categoryFundId, string? categoryName)
    {
        // Validations.
        // TODO: move validations to Category class.
        if (string.IsNullOrEmpty(categoryName))
            throw new EmptyCategoryNameException();
        if (categoryName.Length > Category.MaxLength)
            throw new CategoryNameMaxLengthException(Category.MaxLength);
        if (categoryFundId is null)
            throw new EmptyFundInCategoryException();

        // Check if fund exists or not.
        var fund = await _fundFinder.Find((Guid)categoryFundId);

        // Creation.
        var categoryToCreate = new Category
        {
            Name = categoryName,
            FundId = fund.Id.Value
        };
        if (await _categoriesRepository.Exists(categoryToCreate)) throw new CategoryAlreadyExistsException();
        return await _categoriesRepository.Create(categoryToCreate);
    }
}