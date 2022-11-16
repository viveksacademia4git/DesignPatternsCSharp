using DesignPatternInterfaces;
using IO;
using Models.Components;

namespace Command.Processors;

public class EmailCommunicationExecutor : ICommunicationExecutor
{
    private readonly IEmail _email;

    public EmailCommunicationExecutor(IEmail email)
    {
        _email = email;
    }

    public void Execute()
    {
        $"\n({_email.RefId})".Print();
        "Drafted text content for Email.".Print();
        $"Sending Email on email address '{_email.EmailAddress}'.".Print();
    }
}