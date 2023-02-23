namespace Domain.Exceptions;

public class RegCitzenException : Exception
{
    public RegCitzenException() { }

    public RegCitzenException(string message)
        : base(message) { }

    public RegCitzenException(string message, Exception innerException)
        : base(message, innerException) { }
}