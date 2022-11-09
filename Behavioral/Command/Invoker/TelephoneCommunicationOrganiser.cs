using Command.Processors;
using Models.Components;

namespace Command.Invoker;

public class TelephoneCommunicationOrganiser
{
    private IList<ITelephoneCommunication> _telephoneCommunications;

    public TelephoneCommunicationOrganiser()
    {
        _telephoneCommunications = new List<ITelephoneCommunication>();
    }

    public void PhoneCall(IPhone phone)
    {
        _telephoneCommunications.Add(new PhoneCallCommunication(phone));
    }

    public void Sms(IPhone phone)
    {
        _telephoneCommunications.Add(new SmsCommunication(phone));
    }

    public void Organise()
    {
        if (_telephoneCommunications.Count < 1)
        {
            Console.WriteLine("No phone numbers available to organize communication.");
            return;
        }

        foreach (var telephoneCommunication in _telephoneCommunications)
            telephoneCommunication.Execute();

        _telephoneCommunications = new List<ITelephoneCommunication>();
    }
}