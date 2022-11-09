using ChainOfResponsibility.Enums;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.CommunicationChannels;

public class PhoneCallCommunicationChannel : CommunicationChannel
{
    public PhoneCallCommunicationChannel() : base(CommunicationChannelEnum.PhoneCall) { }

    protected override void PerformCommunication(DataModel dataModel)
    {
        var phone = GetCallingAllowedPhone(dataModel);
        Console.WriteLine($"Scheduling Call with '{dataModel.Name}' for phone number '{phone.Number}'");
        Console.WriteLine($"Call scheduled with '{dataModel.Name}' for phone number '{phone.Number}'");
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