using Command.Processors;
using CommonInterfaces;
using Enums;
using SharedObjects.IO;
using SharedObjects.Models;
using SharedObjects.Models.Components;

namespace ChainOfResponsibility.Chains;

public class PhoneCallCommunicationChannel : CommunicationChannel
{
    public PhoneCallCommunicationChannel() : base(CommunicationChannelEnum.PhoneCall) { }

    protected override void PerformCommunication(Person person,
        ICommunicationProcessInvoker communicationProcessInvoker)
    {
        var phone = GetCallingAllowedPhone(person);

        $"Scheduling Call for '{person.Name}' on phone number '{phone.Number}'.".Print();

        communicationProcessInvoker.Register(new PhoneCallCommunicationProcessor(phone, person));

        $"Call scheduled for '{person.Name}' on phone number '{phone.Number}'.".Print();
    }

    private static IPhone GetCallingAllowedPhone(Person person)
    {
        foreach (var phone in person.Phones)
            if (phone.CallingAllowed)
                return phone;

        var msg = $"Calling is not allowed on any given phone number for '{person.Name}'";
        throw new InvalidOperationException(msg);
    }
}