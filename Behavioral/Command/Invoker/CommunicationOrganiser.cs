
using Command.Processors;
using DesignPatternInterfaces;
using Models;
using Models.Components;

namespace Command.Invoker;

public class CommunicationOrganiser : ICommunicationOrganiser
{
    private IList<ICommunicationProcessor> _telephoneCommunications;

    public CommunicationOrganiser()
    {
        _telephoneCommunications = new List<ICommunicationProcessor>();
    }

    public void Letter(IAddress address, Person person)
    {
        _telephoneCommunications.Add(new LetterCommunicationProcessor(address, person));
    }

    public void Email(IEmail email, Person person)
    {
        _telephoneCommunications.Add(new EmailCommunicationProcessor(email, person));
    }

    public void PhoneCall(IPhone phone, Person person)
    {
        _telephoneCommunications.Add(new PhoneCallCommunicationProcessor(phone, person));
    }

    public void Sms(IPhone phone, Person person)
    {
        _telephoneCommunications.Add(new SmsCommunicationProcessor(phone, person));
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

        _telephoneCommunications = new List<ICommunicationProcessor>();
    }
}