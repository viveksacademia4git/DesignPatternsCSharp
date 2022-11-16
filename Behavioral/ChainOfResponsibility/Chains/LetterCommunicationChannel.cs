using ChainOfResponsibility.Enums;
using DesignPatternInterfaces;
using IO;
using Models;

namespace ChainOfResponsibility.Chains;

public class LetterCommunicationChannel : CommunicationChannel
{
    public LetterCommunicationChannel() : base(CommunicationChannelEnum.Letter) { }

    protected override void PerformCommunication(Person person, ICommunicationOrganiser communicationOrganiser)
    {
        $"Scheduling Letter for '{person.Name}' at address '{person.Address}'.".Print();

        communicationOrganiser.Letter(person.Address);

        $"Letter scheduled to '{person.Name}' at address '{person.Address}'.".Print();
    }
}