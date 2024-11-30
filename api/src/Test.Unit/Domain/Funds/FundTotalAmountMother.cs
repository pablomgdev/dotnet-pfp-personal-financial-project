using Domain.Funds.Models;

namespace Test.Unit.Domain.Funds;

public static class FundTotalAmountMother
{
    public static FundTotalAmount Apply()
    {
        return new FundTotalAmount(0);
    }

    public static FundTotalAmount Random()
    {
        // TODO: improve this random total amount generator.
        var random = new Random();
        return new FundTotalAmount(random.Next(-100, 100));
    }
}