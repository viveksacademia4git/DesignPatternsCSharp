namespace ChainOfResponsibility.Model;

public class Phone : IPhone
{
    public string Number { get; set; }
    public bool CallingAllowed { get; set; }
    public bool SmsActive { get; set; }
}