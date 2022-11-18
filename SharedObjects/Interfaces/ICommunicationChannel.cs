using SharedObjects.Models;

namespace SharedObjects.Interfaces;

public interface ICommunicationChannel
{
    ICommunicationChannel AddNextInChain(ICommunicationChannel communicationChannel);

    void Process(Person person, ICommunicationProcessInvoker communicationProcessInvoker);
}