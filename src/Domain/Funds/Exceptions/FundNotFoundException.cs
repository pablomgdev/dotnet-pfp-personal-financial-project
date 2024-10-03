using Domain.Funds.Models;

namespace Domain.Funds.Exceptions;

public class FundNotFoundException(string message = "fund not found") : Exception(message)
{
    public FundNotFoundException(FundId fundId) : this(
        $"fund {fundId.Value} not found")
    {
    }
}