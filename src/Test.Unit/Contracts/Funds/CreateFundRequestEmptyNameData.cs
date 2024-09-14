using System.Collections;

namespace Test.Unit.Contracts.Funds;

public class CreateFundRequestEmptyNameData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [CreateFundRequestMother.WithoutId(string.Empty)];
        yield return [CreateFundRequestMother.Apply(name: string.Empty)];
    }
}