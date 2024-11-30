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
        yield return [CreateFundRequestMother.ApplyWithoutId(string.Empty)];
        yield return [CreateFundRequestMother.ApplyWithId(name: string.Empty)];
    }
}