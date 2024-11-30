using Domain.Funds.Models;

namespace Domain.Funds.Exceptions;

public class FundAlreadyExistsException(string message = "fund already exists") : Exception(message)
{
    public FundAlreadyExistsException(FundId fundId) : this(
        $"fund {fundId.Value} already exists")
    {
    }
}