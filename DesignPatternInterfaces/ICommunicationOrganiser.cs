using Models.Components;

namespace DesignPatternInterfaces;

public interface ICommunicationOrganiser
{
    void Letter(IAddress address);

    void Email(IEmail email);

    void PhoneCall(IPhone phone);

    void Sms(IPhone phone);

    void Start();
}