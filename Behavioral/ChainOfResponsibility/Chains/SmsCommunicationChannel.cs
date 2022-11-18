using Command.Processors;
using Enums;
using SharedObjects.Interfaces;
using SharedObjects.IO;
using SharedObjects.Models;
using SharedObjects.Models.Components;

namespace ChainOfResponsibility.Chains;

public class SmsCommunicationChannel : CommunicationChannel
{
    public SmsCommunicationChannel() : base(CommunicationChannelEnum.Sms) { }

    protected override void PerformCommunication(Person person,
        ICommunicationProcessInvoker communicationProcessInvoker)
    {
        var phone = GetSmsActivePhone(person);

        $"Scheduling SMS for '{person.Name}' on phone number '{phone.Number}'.".Print();

        communicationProcessInvoker.Register(new SmsCommunicationProcessor(phone, person));

        $"SMS scheduled for '{person.Name}' on phone number '{phone.Number}'.".Print();
    }

    private static IPhone GetSmsActivePhone(Person person)
    {
        foreach (var phone in person.Phones)
            if (phone.SmsActive)
                return phone;

        var msg = $"SMS service is not active on any given phone number for '{person.Name}'";
        throw new InvalidOperationException(msg);
    }
}