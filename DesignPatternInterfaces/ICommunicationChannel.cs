using Models;

namespace DesignPatternInterfaces;

public interface ICommunicationChannel
{
    ICommunicationChannel AddNextInChain(ICommunicationChannel communicationChannel);

    void Process(Person person, ICommunicationProcessInvoker communicationProcessInvoker);
}