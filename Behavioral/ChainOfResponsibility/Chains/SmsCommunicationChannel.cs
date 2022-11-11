using ChainOfResponsibility.Enums;
using DesignPatternInterfaces;
using IO;
using Models;
using Models.Components;
using static ChainOfResponsibility.ProgramSetup;

namespace ChainOfResponsibility.Chains;

public class SmsCommunicationChannel : CommunicationChannel
{
    public SmsCommunicationChannel() : base(CommunicationChannelEnum.Sms) { }

    protected override void PerformCommunication(DataModel dataModel, ICommunicationOrganiser communicationOrganiser)
    {
        var phone = GetSmsActivePhone(dataModel);

        $"Scheduling SMS for '{dataModel.Name}' on phone number '{phone.Number}'.".Print();

        communicationOrganiser.Sms(phone);

        $"SMS scheduled for '{dataModel.Name}' on phone number '{phone.Number}'.".Print();
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