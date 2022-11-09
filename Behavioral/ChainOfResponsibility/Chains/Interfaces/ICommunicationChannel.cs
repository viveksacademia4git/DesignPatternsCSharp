using Models;

namespace ChainOfResponsibility.Chains.Interfaces;

public interface ICommunicationChannel
{
    ICommunicationChannel AddNextInChain(ICommunicationChannel communicationChannel);

    void ProcessResponsibility(DataModel dataModel);
}