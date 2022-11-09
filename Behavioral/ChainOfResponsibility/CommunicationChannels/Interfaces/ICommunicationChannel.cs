using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.DesignPattern.Interfaces;

public interface ICommunicationChannel
{
    ICommunicationChannel AddNextInChain(ICommunicationChannel communicationChannel);

    void ProcessResponsibility(DataModel dataModel);
}