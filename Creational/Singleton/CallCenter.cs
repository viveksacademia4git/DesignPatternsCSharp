using Bogus;
using SharedObjects.IO;
using SharedObjects.Models.ResourceComponents.PhoneCall;
using State;

namespace Singleton;

public class CallCenter : ICommunicationResource<PhoneCall>
{
    private static readonly object InstanceLock = new();

    private static CallCenter? _instance;

    private CallCenter() { }

    public static CallCenter GetInstance
    {
        get
        {
            lock (InstanceLock)
            {
                return _instance ??= new CallCenter();
            }
        }
    }

    public void Assign(PhoneCall phoneCall)
    {
        phoneCall.Operator = FindAvailableCallOperator();

        $"Assigned operator '{phoneCall.Operator.Name}' for phone number '{phoneCall.PhoneNumber}'".Print();

        CallCenterHandler.PhoneCallList.Add(new PhoneCaller(phoneCall));
    }


    private static CallOperator FindAvailableCallOperator()
    {
        var faker = new Faker();
        return new CallOperator { Id = faker.Random.Long(), Name = faker.Person.FullName };
    }
}