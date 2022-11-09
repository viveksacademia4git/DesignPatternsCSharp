using ChainOfResponsibility.Enums;
using Models;

namespace ChainOfResponsibility.Chains;

public class LetterCommunicationChannel : CommunicationChannel
{
    public LetterCommunicationChannel() : base(CommunicationChannelEnum.Letter) { }

    protected override void PerformCommunication(DataModel dataModel)
    {
        Task.Delay(10);
        Console.WriteLine($"Scheduling Letter for '{dataModel.Name}' at address '{dataModel.Address}'");
        Console.WriteLine($"Letter scheduled to '{dataModel.Name}' at address '{dataModel.Address}'");
        Task.Delay(10);
    }
}