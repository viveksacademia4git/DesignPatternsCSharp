using DesignPatternInterfaces;
using Enums;
using IO;
using Models;
using Models.Components;

namespace ChainOfResponsibility.Chains;

public class SmsCommunicationChannel : CommunicationChannel
{
    public SmsCommunicationChannel() : base(CommunicationChannelEnum.Sms) { }

    protected override void PerformCommunication(Person person, ICommunicationOrganiser communicationOrganiser)
    {
        var phone = GetSmsActivePhone(person);

        $"Scheduling SMS for '{person.Name}' on phone number '{phone.Number}'.".Print();

        communicationOrganiser.Sms(phone, person);

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