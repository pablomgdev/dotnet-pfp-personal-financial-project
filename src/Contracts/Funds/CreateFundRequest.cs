namespace Contracts.Funds;

public record CreateFundRequest(
    // Id can be set by the client.
    Guid? Id,
    string? Name,
    string? Description
);