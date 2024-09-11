namespace Domain.Funds.Exceptions;

public class FundNameLengthException(string message = "fund name length is not valid") : Exception(message)
{
    public FundNameLengthException(int maxNameLength) : this(
        $"fund name cannot be more than {maxNameLength} characters")
    {
    }
}