using Contracts.Categories;

namespace Test.Unit.Contracts.Categories;

public static class CreateCategoryRequestMother
{
    // TODO: make default parameters random.
    public static CreateCategoryRequest Apply(string? fundId = "a0b7c0a9-5885-4e6b-b939-452abc93ccc0",
        string? name = "dummy name")
    {
        Guid? fundIdGuid = null;
        if (!string.IsNullOrEmpty(fundId)) fundIdGuid = Guid.Parse(fundId);
        return new CreateCategoryRequest(
            fundIdGuid,
            name
        );
    }

    public static CreateCategoryRequest Random()
    {
        return new CreateCategoryRequest(
            Guid.NewGuid(),
            "dummy name"
        );
    }
}