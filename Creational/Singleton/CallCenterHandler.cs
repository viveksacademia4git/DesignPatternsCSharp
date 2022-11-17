using State;
using State.States;

namespace Singleton;

public class CallCenterHandler
{
    internal static readonly List<PhoneCaller> PhoneCallList = new List<PhoneCaller>();

    public static void StartCalling()
    {
        var phoneCallers = PhoneCallList.Where(callState =>
            callState.PhoneCallState.GetType() == typeof(PhoneCallPending)).ToList();

        if (phoneCallers.Count <= 0)
            return;

        foreach (var phoneCaller in phoneCallers)
            phoneCaller.Result().Publish();

        // ReSharper disable once TailRecursiveCall
        StartCalling();
    }
}