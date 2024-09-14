﻿using Contracts.Funds;

namespace Test.Unit.Contracts.Funds;

// TODO: think if this class is necessary.
public static class CreateFundRequestMother
{
    public static CreateFundRequest Apply(Guid? id = null, string? name = "dummy name",
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

    public static CreateFundRequest WithoutId(string? name = "dummy name", string? description = "dummy description")
    {
        return new CreateFundRequest(
            null,
            name,
            description
        );
    }
}