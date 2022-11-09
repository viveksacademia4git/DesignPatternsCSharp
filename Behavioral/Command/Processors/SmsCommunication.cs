using Models.Components;

namespace Command.Processors;

public class SmsCommunication : ITelephoneCommunication
{
    private readonly IPhone _phone;

    public SmsCommunication(IPhone phone)
    {
        _phone = phone;
    }

    public void Execute()
    {
        Task.Delay(10);
        Console.WriteLine($"\n({_phone.RefId})");
        Console.WriteLine("Drafted text content for SMS.");
        Console.WriteLine($"Sending SMS on phone number '{_phone.Number}'");
        Task.Delay(10);
    }
}