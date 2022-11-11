using DesignPatternInterfaces;
using IO;
using Models.Components;

namespace Command.Processors;

public class SmsCommunicationExecutor : ICommunicationExecutor
{
    private readonly IPhone _phone;

    public SmsCommunicationExecutor(IPhone phone)
    {
        _phone = phone;
    }

    public void Execute()
    {
        $"\n({_phone.RefId})".Print();
        "Drafted text content for SMS.".Print();
        $"Sending SMS on phone number '{_phone.Number}'.".Print();
    }
}