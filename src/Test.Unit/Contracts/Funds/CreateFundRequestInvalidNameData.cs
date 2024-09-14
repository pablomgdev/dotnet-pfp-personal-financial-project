using System.Collections;

namespace Test.Unit.Contracts.Funds;

public class CreateFundRequestInvalidNameData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [CreateFundRequestMother.WithoutId(string.Empty)];
        yield return
            [CreateFundRequestMother.WithoutId("TODO: generate random string that exceeds the limit of characters")];
        yield return [CreateFundRequestMother.Apply(name: string.Empty)];
        yield return
            [CreateFundRequestMother.Apply(name: "TODO: generate random string that exceeds the limit of characters")];
    }
}