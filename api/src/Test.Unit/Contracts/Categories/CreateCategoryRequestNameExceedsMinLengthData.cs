using System.Collections;

namespace Test.Unit.Contracts.Categories;

public class CreateCategoryRequestNameExceedsMinLengthData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [CreateCategoryRequestMother.Apply(name: string.Empty)];
    }
}