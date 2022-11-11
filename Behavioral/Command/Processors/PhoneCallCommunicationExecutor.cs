using DesignPatternInterfaces;
using IO;
using Models.Components;

namespace Command.Processors;

public class PhoneCallCommunicationExecutor : ICommunicationExecutor
{
    private readonly IPhone _phone;

    public PhoneCallCommunicationExecutor(IPhone phone)
    {
        _phone = phone;
    }

    public void Execute()
    {
        $"\n({_phone.RefId})".Print();
        "Assigned call center resource.".Print();
        $"Calling on phone number '{_phone.Number}'.".Print();
    }
}