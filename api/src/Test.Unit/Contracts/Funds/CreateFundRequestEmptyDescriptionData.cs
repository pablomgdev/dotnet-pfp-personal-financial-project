using System.Collections;

namespace Test.Unit.Contracts.Funds;

public class CreateFundRequestEmptyDescriptionData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [CreateFundRequestMother.ApplyWithoutId(description: string.Empty)];
        yield return [CreateFundRequestMother.ApplyWithId(description: string.Empty)];
    }
}