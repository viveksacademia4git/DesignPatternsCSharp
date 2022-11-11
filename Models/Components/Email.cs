namespace Models.Components;

class Email : IEmail
{
    public long RefId { get; set; }
    public string EmailAddress { get; set; }
    public bool Default { get; set; }
}