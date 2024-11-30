using System.Collections;

namespace Test.Unit.Contracts.Categories;

public class CreateCategoryRequestNameExceedsMaxLengthData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return
        [
            CreateCategoryRequestMother.Apply(
                name: "TODO: generate random string that exceeds the limit of characters ..")
        ];
    }
}