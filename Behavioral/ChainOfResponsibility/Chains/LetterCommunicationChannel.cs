using ChainOfResponsibility.Enums;
using DesignPatternInterfaces;
using IO;
using Models;

namespace ChainOfResponsibility.Chains;

public class LetterCommunicationChannel : CommunicationChannel
{
    public LetterCommunicationChannel() : base(CommunicationChannelEnum.Letter) { }

    protected override void PerformCommunication(DataModel dataModel, ICommunicationOrganiser communicationOrganiser)
    {
        $"Scheduling Letter for '{dataModel.Name}' at address '{dataModel.Address}'.".Print();
        
        communicationOrganiser.Letter(dataModel.Address);

        $"Letter scheduled to '{dataModel.Name}' at address '{dataModel.Address}'.".Print();
    }
}