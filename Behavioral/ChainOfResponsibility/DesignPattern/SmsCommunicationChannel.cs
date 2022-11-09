using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.DesignPattern;

public class SmsCommunicationChannel : CommunicationChannel
{
    public SmsCommunicationChannel() : base(Enums.CommunicationChannelEnum.Sms) { }

    protected override void PerformCommunication(DataModel dataModel)
    {
        var phone = GetSmsActivePhone(dataModel);
        Console.WriteLine($"Sending SMS to '{dataModel.Name}' on phone number '{phone.Number}'");
        Console.WriteLine($"SMS sent to '{dataModel.Name}' on phone number '{phone.Number}'");
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