using Domain.Funds.Models;

namespace Test.Unit.Domain.Funds;

public static class FundMother
{
    // TODO: add random datetime.
    public static Fund Apply(FundId? id = null, FundName? name = null, FundDescription? description = null,
        FundTotalAmount? totalAmount = null)
    {
        return new Fund(
            id ?? FundIdMother.Random(),
            name ?? FundNameMother.Random(),
            description ?? FundDescriptionMother.Random(),
            totalAmount ?? FundTotalAmountMother.Random());
    }

    public static Fund Random()
    {
        return Apply();
    }
}