using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.CommunicationChannels;

public class LetterCommunicationChannel : CommunicationChannel
{
    public LetterCommunicationChannel() : base(Enums.CommunicationChannelEnum.Letter) { }

    protected override void PerformCommunication(DataModel dataModel)
    {
        Console.WriteLine($"Sending Letter to '{dataModel.Name}' at '{dataModel.Address}'");
        Console.WriteLine($"Letter sent to '{dataModel.Name}' at '{dataModel.Address}'");
    }
}