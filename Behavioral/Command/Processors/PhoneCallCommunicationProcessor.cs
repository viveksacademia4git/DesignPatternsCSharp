using Adapter;
using SharedObjects.Interfaces;
using SharedObjects.IO;
using SharedObjects.Models;
using SharedObjects.Models.Components;

namespace Command.Processors;

public class PhoneCallCommunicationProcessor : ICommunicationProcessor
{
    private readonly ICommunicationAdapter _communicationAdapter;
    private readonly Person _person;
    private readonly IPhone _phone;

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