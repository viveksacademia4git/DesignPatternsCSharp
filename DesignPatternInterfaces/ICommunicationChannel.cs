using Models;

namespace DesignPatternInterfaces;

public interface ICommunicationChannel
{
    ICommunicationChannel AddNextInChain(ICommunicationChannel communicationChannel);

    void Process(DataModel dataModel, ICommunicationOrganiser communicationOrganiser);
}