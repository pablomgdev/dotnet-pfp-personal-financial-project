using System.Collections;

namespace Test.Unit.Contracts.Categories;

public class CreateCategoryRequestEmptyNameData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [CreateCategoryRequestMother.Apply(name: string.Empty)];
        yield return [CreateCategoryRequestMother.Apply(name: null)];
    }
}