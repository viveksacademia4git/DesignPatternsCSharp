using DesignPatternInterfaces;
using Models;
using Models.Components;
using Singleton;

namespace Adapter;

public class PhoneCallAdapter : ICommunicationAdapter
{
    private readonly IPhone _phone;

    public PhoneCallAdapter(IPhone phone)
    {
        _phone = phone;
    }

    public void Communicate()
    {
        var phoneCall = new PhoneCall { Phone = _phone };

        CallCenter.GetInstance.Assign(phoneCall);
    }
}