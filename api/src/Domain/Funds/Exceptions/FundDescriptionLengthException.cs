namespace Domain.Funds.Exceptions;

public class FundDescriptionLengthException(string message = "fund description length is not valid")
    : Exception(message)
{
    public FundDescriptionLengthException(int maxDescriptionLength) : this(
        $"fund description cannot be more than {maxDescriptionLength} characters")
    {
    }
}