using Application.Funds;
using Contracts.Funds;
using Domain.Funds.Exceptions;
using Domain.Funds.Models;
using Domain.Funds.Repositories;
using Test.Unit.Contracts.Funds;
using Test.Unit.Domain.Funds;
using Fund = Domain.Funds.Models.Fund;

namespace Test.Unit.Application.Funds;

public class FundsCreatorShould
{
    private readonly FundsCreator _fundsCreator;
    private readonly IFundsRepository _fundsRepository;

    public FundsCreatorShould()
    {
        _fundsRepository = Substitute.For<IFundsRepository>();
        _fundsCreator = new FundsCreator(_fundsRepository);
    }

    [Fact]
    public void Invoke_PassingId_CreatesTheFund()
    {
        // Given
        var fund = FundMother.Random();
        var parameters = CreateFundRequestMother.Random();

        _fundsRepository.Get(fund.Id).ReturnsForAnyArgs(null as Task<Fund?>);
        _fundsRepository.Create(fund).ReturnsForAnyArgs(fund);

        // When
        _ = InvokeUseOfCaseWithParameters(_fundsCreator, parameters);

        // Then
        _fundsRepository.Received().Get(Arg.Any<FundId>());
        _fundsRepository.Received().Create(Arg.Any<Fund>());
    }

    [Fact]
    public void Invoke_WithoutPassingId_CreatesTheFund()
    {
        // Given
        var fund = FundMother.Random();
        var parameters = CreateFundRequestMother.WithoutId();

        _fundsRepository.Create(fund).ReturnsForAnyArgs(fund);

        // When
        _ = InvokeUseOfCaseWithParameters(_fundsCreator, parameters);

        // Then
        _fundsRepository.Received().Create(Arg.Any<Fund>());
    }

    [Theory]
    [ClassData(typeof(CreateFundRequestEmptyNameData))]
    public async void Invoke_EmptyName_ThrowsException(CreateFundRequest parameters)
    {
        // Given
        var fund = FundMother.Random();

        _fundsRepository.Get(fund.Id).ReturnsForAnyArgs(null as Task<Fund?>);

        // When
        var exception = await Assert.ThrowsAsync<EmptyFundNameException>(() =>
            InvokeUseOfCaseWithParameters(_fundsCreator, parameters));

        // Then
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    [Theory]
    [ClassData(typeof(CreateFundRequestNameExceedsMaxLengthData))]
    public async void Invoke_NameExceedsNameMaxLength_ThrowsException(CreateFundRequest parameters)
    {
        // Given
        var fund = FundMother.Random();

        _fundsRepository.Get(fund.Id).ReturnsForAnyArgs(null as Task<Fund?>);
        _fundsRepository.Create(fund).ReturnsForAnyArgs(fund);

        // When
        var exception = await Assert.ThrowsAsync<FundNameLengthException>(() =>
            InvokeUseOfCaseWithParameters(_fundsCreator, parameters));

        // Then
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    [Fact]
    public async void Invoke_FundAlreadyExists_ThrowsException()
    {
        // Given
        var fund = FundMother.Random();
        var parameters = CreateFundRequestMother.Random();

        _fundsRepository.Get(fund.Id).ReturnsForAnyArgs(fund);

        // When
        var exception = await Assert.ThrowsAsync<FundAlreadyExistsException>(() =>
            InvokeUseOfCaseWithParameters(_fundsCreator, parameters));

        // Then
        Assert.True(exception is not null, "Everything was OK and no exception was thrown.");
    }

    // TODO: add missing unit tests for the rest of the cases (description empty and description exceeds max length).

    /// <summary>
    ///     Just in case the parameters of the invoke method change. To reduce the number of methods to update.
    /// </summary>
    private static Task<Fund> InvokeUseOfCaseWithParameters(FundsCreator useOfCase, CreateFundRequest parameters)
    {
        return useOfCase.Invoke(parameters.Id, parameters.Name, parameters.Description);
    }
}