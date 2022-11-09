using Models.Components;

namespace Command.Processors;

public class PhoneCallCommunication : ITelephoneCommunication
{
    private readonly IPhone _phone;

    public PhoneCallCommunication(IPhone phone)
    {
        _phone = phone;
    }

    public void Execute()
    {
        Task.Delay(10);
        Console.WriteLine($"\n({_phone.RefId})");
        Console.WriteLine("Assigned call center resource.");
        Console.WriteLine($"Calling on phone number '{_phone.Number}'.");
        Task.Delay(10);
    }
}