using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.DesignPattern;

public class EmailCommunicationChannel : CommunicationChannel
{
    public EmailCommunicationChannel() : base(Enums.CommunicationChannelEnum.Email) { }
    protected override void PerformCommunication(DataModel dataModel)
    {
        Console.WriteLine($"Sending Email to '{dataModel.Name}' at '{dataModel.Email}'");
        Console.WriteLine($"Email sent to '{dataModel.Name}' at '{dataModel.Email}'");
    }
}