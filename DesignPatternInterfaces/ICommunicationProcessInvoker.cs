namespace DesignPatternInterfaces;

public interface ICommunicationProcessInvoker
{
    void Register(ICommunicationProcessor communicationProcessor);

    void Invoke();
}