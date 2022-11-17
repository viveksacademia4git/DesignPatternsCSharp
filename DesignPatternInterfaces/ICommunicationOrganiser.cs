using Models;
using Models.Components;

namespace DesignPatternInterfaces;

public interface ICommunicationOrganiser
{
    void Letter(IAddress address, Person person);

    void Email(IEmail email, Person person);

    void PhoneCall(IPhone phone, Person person);

    void Sms(IPhone phone, Person person);

    void Start();
}