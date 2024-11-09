using Contracts.Funds;

namespace Test.Unit.Contracts.Funds;

// TODO: think if this class is necessary.
public static class CreateFundRequestMother
{
    // TODO: create a random value generator for primitives with the parametrization like number of characters.
    // It should be named Apply but is less confuse to indicate that it generates an ID if it is not passed.
    public static CreateFundRequest ApplyWithId(Guid? id = null, string? name = "dummy name",
        string? description = "dummy description")
    {
        // TODO: Check the use of the ?? operator. It was not working.
        id = Guid.NewGuid();
        return new CreateFundRequest(
            id,
            name,
            description
        );
    }

    public static CreateFundRequest Random()
    {
        return new CreateFundRequest(
            Guid.NewGuid(),
            "dummy name",
            "dummy description"
        );
    }

    public static CreateFundRequest ApplyWithoutId(string? name = "dummy name",
        string? description = "dummy description")
    {
        return new CreateFundRequest(
            null,
            name,
            description
        );
    }
}