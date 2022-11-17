using DesignPatternInterfaces;
using Enums;
using IO;
using Models;
using Models.Components;

namespace ChainOfResponsibility.Chains;

public class PhoneCallCommunicationChannel : CommunicationChannel
{
    public PhoneCallCommunicationChannel() : base(CommunicationChannelEnum.PhoneCall) { }

    protected override void PerformCommunication(Person person, ICommunicationOrganiser communicationOrganiser)
    {
        var phone = GetCallingAllowedPhone(person);

        $"Scheduling Call for '{person.Name}' on phone number '{phone.Number}'.".Print();

        communicationOrganiser.PhoneCall(phone, person);

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