using Command.Processors;
using CommonInterfaces;
using Enums;
using SharedObjects.IO;
using SharedObjects.Models;

namespace ChainOfResponsibility.Chains;

public class LetterCommunicationChannel : CommunicationChannel
{
    public LetterCommunicationChannel() : base(CommunicationChannelEnum.Letter) { }

    protected override void PerformCommunication(Person person,
        ICommunicationProcessInvoker communicationProcessInvoker)
    {
        $"Scheduling Letter for '{person.Name}' at address '{person.Address}'.".Print();

        communicationProcessInvoker.Register(new LetterCommunicationProcessor(person.Address, person));

        $"Letter scheduled to '{person.Name}' at address '{person.Address}'.".Print();
    }
}