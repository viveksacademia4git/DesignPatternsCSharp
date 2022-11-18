namespace SharedObjects.Models.Components;

public interface IEmail
{
    long RefId { get; }
    string EmailAddress { get; }
    bool Default { get; }
}