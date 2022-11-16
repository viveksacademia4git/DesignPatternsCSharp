using IO;
using Models;

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
        $"*** Operator '{PhoneCall.Operator.Name}' completed phone call for '{PhoneCall.Phone.Number}'\n".Print();
    }
}