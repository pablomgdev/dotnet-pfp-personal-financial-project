using Application.Funds;
using Domain.Funds.Repositories;
using Domain.Funds.Services;
using Test.Unit.Contracts.Funds;
using Test.Unit.Domain.Funds;

namespace Test.Unit.Application.Funds;

public class FundsCreatorShould
{
    private readonly FundFinder _fundFinder;
    private readonly FundsCreator _fundsCreator;
    private readonly IFundsRepository _fundsRepository;

    public FundsCreatorShould()
    {
        _fundsRepository = Substitute.For<IFundsRepository>();
        _fundFinder = new FundFinder(_fundsRepository);
        _fundsCreator = new FundsCreator(_fundsRepository, _fundFinder);
    }

    // TODO: create a set of date for executing the tests with different possibilities.
    [Fact]
    public void Invoke_WithoutPassingId_CreatesAndReturnsTheFundCreated()
    {
        // Given
        var fund = FundMother.Random();
        var parameters = CreateFundRequestMother.WithoutId();

        _fundsRepository.Create(fund).Returns(fund);

        // When
        _ = _fundsCreator.Invoke(parameters.Id, parameters.Name, parameters.Description);

        // Then
        // TODO: why this does not work? See if is because of the fund.
        _fundsRepository.Received().Create(fund);
    }

    // TODO: create more test cases like Invoke_PassingId_CreatesAndReturnsTheFundCreated.
}