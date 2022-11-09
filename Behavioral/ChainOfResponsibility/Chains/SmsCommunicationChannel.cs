using ChainOfResponsibility.Enums;
using Models;
using Models.Components;

namespace ChainOfResponsibility.Chains;

public class SmsCommunicationChannel : CommunicationChannel
{
    public SmsCommunicationChannel() : base(CommunicationChannelEnum.Sms) { }

    protected override void PerformCommunication(DataModel dataModel)
    {
        Task.Delay(10);

        var phone = GetSmsActivePhone(dataModel);

        Console.WriteLine($"Scheduling SMS for '{dataModel.Name}' on phone number '{phone.Number}'");

        ProgramSetup.SmsCommunications.Add(phone);

        Console.WriteLine($"SMS scheduled for '{dataModel.Name}' on phone number '{phone.Number}'");

        Task.Delay(10);
    }

    private static IPhone GetSmsActivePhone(DataModel dataModel)
    {
        foreach (var phone in dataModel.Phones)
            if (phone.SmsActive)
                return phone;

        var msg = $"SMS service is not active on any given phone number for '{dataModel.Name}'";
        throw new InvalidOperationException(msg);
    }
}