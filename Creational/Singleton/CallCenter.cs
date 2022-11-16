using Bogus;
using IO;
using Models;
using State;
using State.States;

namespace Singleton;

public class CallCenter : ICommunicationResource<PhoneCall>
{
    private static readonly object InstanceLock = new();

    private CallCenter() { }

    private static CallCenter? _instance;

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

        $"Assigned operator '{phoneCall.Operator.Name}' for phone number '{phoneCall.Phone.Number}'".Print();

        PhoneCallList.Add(new PhoneCaller(phoneCall));
    }


    public static void StartCalling()
    {
        var phoneCallers = PhoneCallList.Where(callState =>
            callState.PhoneCallState.GetType() == typeof(PhoneCallPending)).ToList();

        if (phoneCallers.Count <= 0)
            return;

        foreach (var phoneCaller in phoneCallers)
        {
            phoneCaller.Result().Publish();
        }

        // ReSharper disable once TailRecursiveCall
        StartCalling();
    }

    private static CallOperator FindAvailableCallOperator()
    {
        var faker = new Faker();
        return new CallOperator { Id = faker.Random.Long(), Name = faker.Person.FullName };
    }

    private static List<PhoneCaller> PhoneCallList = new List<PhoneCaller>();
}