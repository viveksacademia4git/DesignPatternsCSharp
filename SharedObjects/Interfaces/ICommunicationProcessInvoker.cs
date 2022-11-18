namespace SharedObjects.Interfaces;

public interface ICommunicationProcessInvoker
{
    void Register(ICommunicationProcessor communicationProcessor);

    void Invoke();
}