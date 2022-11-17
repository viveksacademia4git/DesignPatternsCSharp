using ChainOfResponsibility.Exceptions;
using DesignPatternInterfaces;
using Enums;
using Models;

namespace ChainOfResponsibility.Chains;

public abstract class CommunicationChannel : ICommunicationChannel
{
    private readonly CommunicationChannelEnum _communicationChannelEnum;

    private ICommunicationChannel? _nextInChain;

    protected CommunicationChannel(CommunicationChannelEnum communicationChannelEnum)
    {
        _communicationChannelEnum = communicationChannelEnum;
    }

    // Didn't want to use the constructor to add next component in chain
    public ICommunicationChannel AddNextInChain(ICommunicationChannel nextInChain)
    {
        if (_nextInChain is null)
            _nextInChain = nextInChain;
        else
            _nextInChain.AddNextInChain(nextInChain);

        return this;
    }

    public void Process(Person person, ICommunicationOrganiser communicationOrganiser)
    {
        var isResponsible = _communicationChannelEnum.Equals(person.DefaultCommunicationChannelEnum);

        try
        {
            if (isResponsible)
                PerformCommunication(person, communicationOrganiser);
            else
                PassOnResponsibilityToNextInChain(person, communicationOrganiser);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"===>>> *** {exception.Message} *** <<<===");
        }
    }

    private void PassOnResponsibilityToNextInChain(Person person, ICommunicationOrganiser communicationOrganiser)
    {
        if (_nextInChain is null)
        {
            const string msg = "The chain of communication channel has at-least one missing communication channel";
            throw new InvalidCommunicationChainImplementedException(msg);
        }

        _nextInChain.Process(person, communicationOrganiser);
    }

    protected abstract void PerformCommunication(Person person, ICommunicationOrganiser communicationOrganiser);
}