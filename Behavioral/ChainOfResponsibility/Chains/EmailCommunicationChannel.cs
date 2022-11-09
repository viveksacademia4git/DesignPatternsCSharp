using ChainOfResponsibility.Enums;
using Models;

namespace ChainOfResponsibility.Chains;

public class EmailCommunicationChannel : CommunicationChannel
{
    public EmailCommunicationChannel() : base(CommunicationChannelEnum.Email) { }

    protected override void PerformCommunication(DataModel dataModel)
    {
        Task.Delay(10);
        Console.WriteLine($"Scheduling Email for '{dataModel.Name}' at email '{dataModel.Email}'");
        Console.WriteLine($"Email scheduled for '{dataModel.Name}' at email '{dataModel.Email}'");
        Task.Delay(10);
    }
}