using System.Collections;

namespace Test.Unit.Contracts.Funds;

public class CreateFundRequestNameExceedsMaxLengthData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            CreateFundRequestMother.ApplyWithoutId("TODO: generate random string that exceeds the limit of characters")
        ];
        yield return
        [
            CreateFundRequestMother.ApplyWithId(
                name: "TODO: generate random string that exceeds the limit of characters")
        ];
    }
}