using SharedObjects.IO;
using SharedObjects.Models.ResourceComponents.PhoneCall;

namespace State.States;

public class PhoneCallPending : IPhoneCallState
{
    public PhoneCallPending(PhoneCall phoneCall)
    {
        PhoneCall = phoneCall;
    }

    public PhoneCall PhoneCall { get; }

    public void Handle()
    {
        $"--- Call not completed for phone number '{PhoneCall.PhoneNumber}'\n".Print();
    }
}