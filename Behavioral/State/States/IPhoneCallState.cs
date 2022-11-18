using SharedObjects.Models.ResourceComponents.PhoneCall;

namespace State.States;

public interface IPhoneCallState
{
    PhoneCall PhoneCall { get; }
    void Handle();
}