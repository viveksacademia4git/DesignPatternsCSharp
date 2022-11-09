namespace ChainOfResponsibility.Model;

public interface IPhone
{
    public string Number { get; }
    public bool CallingAllowed { get; }
    public bool SmsActive { get; }
}