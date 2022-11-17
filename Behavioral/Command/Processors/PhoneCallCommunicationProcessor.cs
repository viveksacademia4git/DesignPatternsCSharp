using Adapter;
using DesignPatternInterfaces;
using IO;
using Models;
using Models.Components;

namespace Command.Processors;

public class PhoneCallCommunicationProcessor : ICommunicationProcessor
{
    private readonly ICommunicationAdapter _communicationAdapter;
    private readonly IPhone _phone;
    private readonly Person _person;

    public PhoneCallCommunicationProcessor(IPhone phone, Person person)
    {
        _phone = phone;
        _person = person;
        _communicationAdapter = new PhoneCallAdapter(phone);
    }

    public void Execute()
    {
        $"\n({_phone.RefId})".Print();
        // "Assigning call center resource.".Print();
        $"Communication with '{_person.Name}' is sent to call center for phone number '{_phone.Number}'.".Print();
        _communicationAdapter.Communicate();
    }
}