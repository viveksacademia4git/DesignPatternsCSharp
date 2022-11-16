using Bogus;
using DesignPatternInterfaces;
using Models;
using Models.Components;
using Singleton;

namespace Adapter;

public class PhoneCallAdapter : ICommunicationAdapter
{
    private readonly CallCenter _callCenter;
    private readonly IPhone _phone;

    public PhoneCallAdapter(CallCenter callCenter, IPhone phone)
    {
        _callCenter = callCenter;
        _phone = phone;
    }

    public void Communicate()
    {
        var callOperator = FindAvailableCallOperator();

        var phoneCall = new PhoneCall { Phone = _phone, Operator = callOperator };

        _callCenter.Communicate(phoneCall);
    }

    private static CallOperator FindAvailableCallOperator()
    {
        var faker = new Faker();
        return new CallOperator { Id = faker.Random.Long(), Name = faker.Person.FullName };
    }
}