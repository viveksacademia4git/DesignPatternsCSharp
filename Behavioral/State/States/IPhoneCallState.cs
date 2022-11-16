using Models;

namespace State.States;

public interface IPhoneCallState
{
    PhoneCall PhoneCall { get; }
    void Handle();
}