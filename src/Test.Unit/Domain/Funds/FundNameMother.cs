using Domain.Funds.Models;

namespace Test.Unit.Domain.Funds;

public static class FundNameMother
{
    public static FundName Apply()
    {
        return new FundName("dummy value");
    }

    public static FundName Random()
    {
        return new FundName("random name");
    }
}