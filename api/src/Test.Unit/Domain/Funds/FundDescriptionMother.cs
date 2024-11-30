using Domain.Funds.Models;

namespace Test.Unit.Domain.Funds;

public static class FundDescriptionMother
{
    public static FundDescription Apply()
    {
        return new FundDescription("dummy description");
    }

    public static FundDescription Random()
    {
        return new FundDescription("random description");
    }
}