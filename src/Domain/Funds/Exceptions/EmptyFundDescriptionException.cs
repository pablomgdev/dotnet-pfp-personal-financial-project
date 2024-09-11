namespace Domain.Funds.Exceptions;

public class EmptyFundDescriptionException(string message = "fund description cannot be empty") : Exception(message);