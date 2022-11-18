using IO;
using Models.ResourceComponents.PhoneCall;

namespace State.States;

public class PhoneCallCompleted : IPhoneCallState
{
    public PhoneCallCompleted(PhoneCall phoneCall)
    {
        PhoneCall = phoneCall;
    }

    public PhoneCall PhoneCall { get; }

    public void Handle()
    {
        $"*** Operator '{PhoneCall.Operator.Name}' completed phone call for '{PhoneCall.PhoneNumber}'\n".Print();
    }
}