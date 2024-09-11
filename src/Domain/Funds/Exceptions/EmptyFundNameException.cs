namespace Domain.Funds.Exceptions;

public class EmptyFundNameException(string message = "fund name cannot be empty") : Exception(message);