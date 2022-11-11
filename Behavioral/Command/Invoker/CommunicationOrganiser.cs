using Command.Processors;
using DesignPatternInterfaces;
using Models.Components;

namespace Command.Invoker;

public class CommunicationOrganiser : ICommunicationOrganiser
{
    private IList<ICommunicationExecutor> _telephoneCommunications;

    public CommunicationOrganiser()
    {
        _telephoneCommunications = new List<ICommunicationExecutor>();
    }

    public void Letter(IAddress address)
    {
        _telephoneCommunications.Add(new LetterCommunicationExecutor(address));
    }

    public void Email(IEmail email)
    {
        _telephoneCommunications.Add(new EmailCommunicationExecutor(email));
    }

    public void PhoneCall(IPhone phone)
    {
        _telephoneCommunications.Add(new PhoneCallCommunicationExecutor(phone));
    }

    public void Sms(IPhone phone)
    {
        _telephoneCommunications.Add(new SmsCommunicationExecutor(phone));
    }

    public void Start()
    {
        if (_telephoneCommunications.Count < 1)
        {
            Console.WriteLine("No phone numbers available to start communication.");
            return;
        }

        foreach (var telephoneCommunication in _telephoneCommunications)
            telephoneCommunication.Execute();

        _telephoneCommunications = new List<ICommunicationExecutor>();
    }
}