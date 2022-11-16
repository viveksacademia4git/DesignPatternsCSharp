namespace Singleton;

public interface ICommunicationResource<in TCom>
{
    void Assign(TCom communicationMedium);
}