using ChainOfResponsibility.Enums;
using DesignPatternInterfaces;
using IO;
using Models;
using Models.Components;

namespace ChainOfResponsibility.Chains;

public class PhoneCallCommunicationChannel : CommunicationChannel
{
    public PhoneCallCommunicationChannel() : base(CommunicationChannelEnum.PhoneCall) { }

    protected override void PerformCommunication(DataModel dataModel, ICommunicationOrganiser communicationOrganiser)
    {
        var phone = GetCallingAllowedPhone(dataModel);

        $"Scheduling Call for '{dataModel.Name}' on phone number '{phone.Number}'.".Print();

        communicationOrganiser.PhoneCall(phone);

        $"Call scheduled for '{dataModel.Name}' on phone number '{phone.Number}'.".Print();
    }

    private static IPhone GetCallingAllowedPhone(DataModel dataModel)
    {
        foreach (var phone in dataModel.Phones)
            if (phone.CallingAllowed)
                return phone;

        var msg = $"Calling is not allowed on any given phone number for '{dataModel.Name}'";
        throw new InvalidOperationException(msg);
    }
}