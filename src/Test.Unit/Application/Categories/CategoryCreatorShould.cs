using Application.Categories;
using Contracts.Categories;
using Domain.Categories.Exceptions;
using Domain.Categories.Repositories;
using Domain.Funds.Exceptions;
using Domain.Funds.Models;
using Domain.Funds.Repositories;
using Test.Unit.Contracts.Categories;
using Test.Unit.Domain.Funds;
using Category = Domain.Categories.Models.Category;

namespace Test.Unit.Application.Categories;

public class CategoryCreatorShould
{
    private readonly CategoriesCreator _categoriesCreator;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IFundsRepository _fundsRepository;

    public CategoryCreatorShould()
    {
        _categoriesRepository = Substitute.For<ICategoriesRepository>();
        _fundsRepository = Substitute.For<IFundsRepository>();
        _categoriesCreator = new CategoriesCreator(_categoriesRepository, _fundsRepository);
    }

    [Fact]
    public async void Invoke_CreatesTheCategory()
    {
        // Given.
        var parameters = CreateCategoryRequestMother.Random();

        // TODO: this line below could be refactored.
        _fundsRepository.Get(Arg.Any<FundId>()).ReturnsForAnyArgs(Task.FromResult<Fund?>(
            FundMother.Apply(new FundId(parameters.FundId.Value))
        ));

        _categoriesRepository.Exists(Arg.Any<Category>()).ReturnsForAnyArgs(Task.FromResult(false));

        // When.
        var category = InvokeUseCase(parameters);

        // Then.
        await _categoriesRepository.Received().Create(Arg.Any<Category>());
    }

    [Fact]
    public async void Invoke_FundNotExists_ThrowsException()
    {
        // Given.
        var parameters = CreateCategoryRequestMother.Random();

        _fundsRepository.Get(Arg.Any<FundId>()).ReturnsForAnyArgs(Task.FromResult<Fund?>(null));

        // When.
        var exception = await Assert.ThrowsAsync<FundNotFoundException>(() => InvokeUseCase(parameters));

        // Then
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    [Fact]
    public async void Invoke_CategoryAlreadyExists_ThrowsException()
    {
        // Given.
        var parameters = CreateCategoryRequestMother.Random();

        _fundsRepository.Get(Arg.Any<FundId>()).ReturnsForAnyArgs(Task.FromResult<Fund?>(
            FundMother.Apply(new FundId(parameters.FundId.Value))
        ));

        _categoriesRepository.Exists(Arg.Any<Category>()).ReturnsForAnyArgs(Task.FromResult(true));

        // When.
        var exception = await Assert.ThrowsAsync<CategoryAlreadyExistsException>(() => InvokeUseCase(parameters));

        // Then
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    [Theory]
    [ClassData(typeof(CreateCategoryRequestNameExceedsMaxLengthData))]
    public async void Invoke_NameExceedsMaxLengthData_ThrowsException(CreateCategoryRequest parameters)
    {
        // When
        var exception = await Assert.ThrowsAsync<CategoryNameMaxLengthException>(() => InvokeUseCase(parameters));

        // Then
        // TODO: move this message to a global constant string to use it in all the tests with exceptions.
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    [Theory]
    [ClassData(typeof(CreateCategoryRequestEmptyNameData))]
    public async void Invoke_EmptyName_ThrowsException(CreateCategoryRequest parameters)
    {
        // When
        var exception = await Assert.ThrowsAsync<EmptyCategoryNameException>(() => InvokeUseCase(parameters));

        // Then
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    [Fact]
    public async void Invoke_EmptyFund_ThrowsException()
    {
        // Given
        var parameters = CreateCategoryRequestMother.Apply(null);

        // When
        var exception = await Assert.ThrowsAsync<EmptyFundInCategoryException>(() => InvokeUseCase(parameters));

        // Then
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    private async Task<Category> InvokeUseCase(CreateCategoryRequest parameters)
    {
        return await _categoriesCreator.Invoke(parameters.FundId, parameters.Name);
    }
}