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

    public void Process(Person person, ICommunicationProcessInvoker communicationProcessInvoker)
    {
        var isResponsible = _communicationChannelEnum.Equals(person.DefaultCommunicationChannelEnum);

        try
        {
            if (isResponsible)
                PerformCommunication(person, communicationProcessInvoker);
            else
                PassOnResponsibilityToNextInChain(person, communicationProcessInvoker);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"===>>> *** {exception.Message} *** <<<===");
        }
    }

    private void PassOnResponsibilityToNextInChain(Person person,
        ICommunicationProcessInvoker communicationProcessInvoker)
    {
        if (_nextInChain is null)
        {
            const string msg = "The chain of communication channel has at-least one missing communication channel";
            throw new InvalidCommunicationChainImplementedException(msg);
        }

        _nextInChain.Process(person, communicationProcessInvoker);
    }

    protected abstract void PerformCommunication(Person person,
        ICommunicationProcessInvoker communicationProcessInvoker);
}