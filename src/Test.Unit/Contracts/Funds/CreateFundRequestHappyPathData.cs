using System.Collections;

namespace Test.Unit.Contracts.Funds;

public class CreateFundRequestHappyPathData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [CreateFundRequestMother.WithoutId()];
        yield return [CreateFundRequestMother.Random()];
    }
}