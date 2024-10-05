using Application.Categories;
using Contracts.Categories;
using Domain.Categories.Repositories;
using Category = Domain.Categories.Models.Category;

namespace Test.Unit.Application.Categories;

public class CategoryCreatorShould
{
    private readonly CategoriesCreator _categoriesCreator;
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoryCreatorShould()
    {
        _categoriesRepository = Substitute.For<ICategoriesRepository>();
        _categoriesCreator = new CategoriesCreator(_categoriesRepository);
    }

    [Fact]
    public async void Invoke_CreatesTheCategory()
    {
        // Given.
        // TODO: create a mother object for CreateCategoryRequest class (CreateCategoryRequestMother).
        // TODO: create a data class with different cases using CreateCategoryRequestMother.
        var parameters = new CreateCategoryRequest(Guid.NewGuid(), string.Empty, 0);

        // When.
        var category = InvokeUseCase(parameters);

        // Then.
        await _categoriesRepository.Received().Create(Arg.Any<Category>());
    }

    private async Task<Category> InvokeUseCase(CreateCategoryRequest parameters)
    {
        return await _categoriesCreator.Invoke(parameters.FundId, parameters.Name, parameters.Limit);
    }
}