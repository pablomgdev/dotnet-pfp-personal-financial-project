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
        yield return [CreateFundRequestMother.WithoutId(description: string.Empty)];
        yield return [CreateFundRequestMother.Apply(description: string.Empty)];
    }
}