namespace Models.Components;

public interface IPhone
{
    public long RefId { get; }
    public string Number { get; }
    public bool CallingAllowed { get; }
    public bool SmsActive { get; }
}