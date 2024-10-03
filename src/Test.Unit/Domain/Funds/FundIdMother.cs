using Domain.Funds.Models;

namespace Test.Unit.Domain.Funds;

public class FundIdMother
{
    public static FundId Apply()
    {
        return new FundId(Guid.NewGuid());
    }

    public static FundId Random()
    {
        return new FundId(Guid.NewGuid());
    }
}