namespace Domain.Transactions.Exceptions;

public class TransactionDescriptionLengthException(string message = "transaction description length is not valid")
    : Exception(message)
{
    public TransactionDescriptionLengthException(int maxDescriptionLength) : this(
        $"transaction description cannot be more than {maxDescriptionLength} characters")
    {
    }
}