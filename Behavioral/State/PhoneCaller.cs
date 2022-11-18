using Bogus;
using SharedObjects.IO;
using SharedObjects.Models.ResourceComponents.PhoneCall;
using State.States;

namespace State;

public class PhoneCaller : IPhoneCallerAttempt, IPhoneCallerResult
{
    public PhoneCaller(PhoneCall phoneCall)
    {
        PhoneCallState = new PhoneCallPending(phoneCall);
    }

    public IPhoneCallState PhoneCallState { get; private set; }

    public IPhoneCallerResult Result()
    {
        $"Operator '{PhoneCallState.PhoneCall.Operator.Name}' is calling phone number '{PhoneCallState.PhoneCall.PhoneNumber}'"
            .Print();

        var callResult = new Faker().Random.Bool();

        if (callResult)
            PhoneCallState = new PhoneCallCompleted(PhoneCallState.PhoneCall);

        return this;
    }

    public void Publish()
    {
        PhoneCallState.Handle();
    }
}