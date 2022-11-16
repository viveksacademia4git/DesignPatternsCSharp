namespace Singleton;

public interface ICommunicationResource<in TCom>
{
    void Communicate(TCom communicationMedium);
}