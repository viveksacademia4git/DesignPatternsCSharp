using Bridge.Abstraction2;
using CommonInterfaces;
using Factory;
using SharedObjects.IO;
using SharedObjects.Models;
using SharedObjects.Models.Components;

namespace Command.Processors;

public class EmailCommunicationProcessor : ICommunicationProcessor
{
    private readonly ICommunicationHandler _communicationHandler;
    private readonly IEmail _email;
    private readonly Person _person;

    public EmailCommunicationProcessor(IEmail email, Person person)
    {
        _email = email;
        _person = person;
        _communicationHandler = new EmailCommunicationHandler(email);
    }

    public void Execute()
    {
        $"\n({_email.RefId})".Print();

        var billHandler = new BillHandlerFactory(_communicationHandler).Get(_person);
        billHandler.Handle();

        // "Drafted text content for Email.".Print();
        // $"Sending Email on email address '{_email.EmailAddress}'.".Print();
    }
}