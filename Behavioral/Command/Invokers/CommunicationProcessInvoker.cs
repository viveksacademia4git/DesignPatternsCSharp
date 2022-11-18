using SharedObjects.Interfaces;

namespace Command.Invokers;

public class CommunicationProcessInvoker : ICommunicationProcessInvoker
{
    private IList<ICommunicationProcessor> _communicationProcessors;

    public CommunicationProcessInvoker()
    {
        _communicationProcessors = new List<ICommunicationProcessor>();
    }

    public void Register(ICommunicationProcessor communicationProcessor)
    {
        _communicationProcessors.Add(communicationProcessor);
    }

    public void Invoke()
    {
        if (_communicationProcessors.Count < 1)
        {
            Console.WriteLine("No phone numbers available to start communication.");
            return;
        }

        foreach (var telephoneCommunication in _communicationProcessors)
            telephoneCommunication.Execute();

        _communicationProcessors = new List<ICommunicationProcessor>();
    }
}