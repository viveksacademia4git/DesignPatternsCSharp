namespace Models.Components;

public class Phone : IPhone
{
    public long RefId { get; set; }
    public string Number { get; set; }
    public bool CallingAllowed { get; set; }
    public bool SmsActive { get; set; }
}