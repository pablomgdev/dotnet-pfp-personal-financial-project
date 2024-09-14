using Application.Funds;
using Contracts.Funds;
using Domain.Funds.Exceptions;
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

    [Theory]
    [ClassData(typeof(CreateFundRequestHappyPathData))]
    public void Invoke_HappyPath_CreatesTheFund(CreateFundRequest parameters)
    {
        // Given
        var fund = FundMother.Random();

        _fundsRepository.Get(fund.Id).Returns(null as Task<Fund?>);
        _fundsRepository.Create(fund).Returns(fund);

        // When
        _ = InvokeUseOfCaseWithParameters(_fundsCreator, parameters);

        // Then
        // This could be deleted as only check if Create method has been executed.
        var findNumberOfCalls = _fundsRepository
            .ReceivedCalls()
            .Count(x => x.GetMethodInfo().Name == nameof(_fundsRepository.Get));
        Assert.InRange(findNumberOfCalls, 0, 1);
        _fundsRepository.Received().Create(Arg.Any<Fund>());
    }

    [Theory]
    [ClassData(typeof(CreateFundRequestInvalidNameData))]
    public async void Invoke_InvalidParameters_ThrowsException(CreateFundRequest parameters)
    {
        // Given
        var fund = FundMother.Random();

        _fundsRepository.Get(fund.Id).Returns(null as Task<Fund?>);
        _fundsRepository.Create(fund).Returns(fund);

        // When
        var exception =
            await Assert.ThrowsAnyAsync<Exception>(() => InvokeUseOfCaseWithParameters(_fundsCreator, parameters));

        // Then
        var exceptionWasThrown = exception is EmptyFundNameException
            or FundNameLengthException
            or FundAlreadyExistsException
            or EmptyFundDescriptionException
            or FundDescriptionLengthException;
        Assert.True(exceptionWasThrown, "Everything was OK and no exception was thrown.");
    }

    /// <summary>
    ///     Just in case the parameters of the invoke method change. To reduce the number of methods to update.
    /// </summary>
    private static Task<Fund> InvokeUseOfCaseWithParameters(FundsCreator useOfCase, CreateFundRequest parameters)
    {
        return useOfCase.Invoke(parameters.Id, parameters.Name, parameters.Description);
    }
}