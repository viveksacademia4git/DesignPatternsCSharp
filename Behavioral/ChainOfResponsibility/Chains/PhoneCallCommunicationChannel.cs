using ChainOfResponsibility.Enums;
using Models;
using Models.Components;

namespace ChainOfResponsibility.Chains;

public class PhoneCallCommunicationChannel : CommunicationChannel
{
    public PhoneCallCommunicationChannel() : base(CommunicationChannelEnum.PhoneCall) { }

    protected override void PerformCommunication(DataModel dataModel)
    {
        Task.Delay(10);

        var phone = GetCallingAllowedPhone(dataModel);

        Console.WriteLine($"Scheduling Call for '{dataModel.Name}' on phone number '{phone.Number}'");

        ProgramSetup.PhoneCallCommunications.Add(phone);

        Console.WriteLine($"Call scheduled for '{dataModel.Name}' on phone number '{phone.Number}'");

        Task.Delay(10);
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