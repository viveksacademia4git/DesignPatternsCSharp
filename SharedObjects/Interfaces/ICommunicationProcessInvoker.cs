namespace CommonInterfaces;

public interface ICommunicationProcessInvoker
{
    void Register(ICommunicationProcessor communicationProcessor);

    void Invoke();
}