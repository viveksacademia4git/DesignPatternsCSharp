using IO;
using Models;

namespace Singleton;

public class CallCenter : ICommunicationResource<PhoneCall>
{
    private static readonly object InstanceLock = new ();

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

    public void Communicate(PhoneCall phoneCall)
    {
        var msg = $"operator '{phoneCall.Operator.Name}' and phone number '{phoneCall.Phone.Number}'";

        $"Saving phone call communication between {msg}".Print();

        $"Calling started between {msg} ".Print();
    }
}