using Test.Unit.Domain.Funds;

namespace Test.Unit.Application.Funds;

public class FundsCreatorShould
{
    [Fact]
    public void Invoke_WithoutPassingId_CreatesAndReturnsTheFundCreated()
    {
        // Given
        // TODO: see how to set a value to null without setting it to random value like now with Apply method.
        // TODO: see if this should be called Mother or Stub.
        var fund = FundMother.Random();

        // When
        // TODO: call to FundsCreator passing the fund.

        // Then
        // TODO: compare the result got with the expected result.
        // TODO: create a set of date for executing the tests with different possibilities.
        fund.Should().Be(fund);
    }

    // TODO: create more test cases like Invoke_PassingId_CreatesAndReturnsTheFundCreated.
}