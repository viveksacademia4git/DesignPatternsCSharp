
using ChainOfResponsibility.Enums;
using ChainOfResponsibility.Exceptions;
using DesignPatternInterfaces;
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

    public void Process(DataModel dataModel, ICommunicationOrganiser communicationOrganiser)
    {
        var isResponsible = _communicationChannelEnum.Equals(dataModel.DefaultCommunicationChannelEnum);

        try
        {
            if (isResponsible)
                PerformCommunication(dataModel, communicationOrganiser);
            else
                PassOnResponsibilityToNextInChain(dataModel, communicationOrganiser);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"===>>> *** {exception.Message} *** <<<===");
        }
    }

    private void PassOnResponsibilityToNextInChain(DataModel dataModel, ICommunicationOrganiser communicationOrganiser)
    {
        if (_nextInChain is null)
        {
            const string msg = "The chain of communication channel has at-least one missing communication channel";
            throw new InvalidCommunicationChainImplementedException(msg);
        }

        _nextInChain.Process(dataModel, communicationOrganiser);
    }

    protected abstract void PerformCommunication(DataModel dataModel, ICommunicationOrganiser communicationOrganiser);
}