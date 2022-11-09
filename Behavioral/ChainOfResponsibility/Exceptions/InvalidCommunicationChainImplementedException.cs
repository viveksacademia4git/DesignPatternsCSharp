namespace ChainOfResponsibility.Exceptions;

public class InvalidCommunicationChainImplementedException : InvalidOperationException
{
    public InvalidCommunicationChainImplementedException(string message) : base(message) { }
}