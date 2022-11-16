using Adapter;
using DesignPatternInterfaces;
using IO;
using Models.Components;

namespace Command.Processors;

public class PhoneCallCommunicationExecutor : ICommunicationExecutor
{
    private readonly ICommunicationAdapter _communicationAdapter;
    private readonly IPhone _phone;

    public PhoneCallCommunicationExecutor(IPhone phone)
    {
        _phone = phone;
        _communicationAdapter = new PhoneCallAdapter(phone);
    }

    public void Execute()
    {
        $"\n({_phone.RefId})".Print();
        // "Assigning call center resource.".Print();
        $"Phone call communication request sent to call center for phone number '{_phone.Number}'.".Print();
        _communicationAdapter.Communicate();
    }
}