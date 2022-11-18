using SharedObjects.Interfaces;
using SharedObjects.Models.Components;
using SharedObjects.Models.ResourceComponents.PhoneCall;
using Singleton;

namespace Adapter;

/// <summary>
///     Converts the interface of a class into another interface clients expect.
/// </summary>
public class PhoneCallAdapter : ICommunicationAdapter
{
    private readonly IPhone _phone;

    public PhoneCallAdapter(IPhone phone)
    {
        _phone = phone;
    }

    public void Communicate()
    {
        var phoneCall = new PhoneCall { PhoneNumber = _phone.Number };

        CallCenter.GetInstance.Assign(phoneCall);
    }
}