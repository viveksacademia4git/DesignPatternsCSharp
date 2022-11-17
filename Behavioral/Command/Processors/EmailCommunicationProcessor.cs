using Bridge.Abstraction2;
using DesignPatternInterfaces;
using Factory;
using IO;
using Models;
using Models.Components;

namespace Command.Processors;

public class EmailCommunicationProcessor : ICommunicationProcessor
{
    private readonly IEmail _email;
    private readonly Person _person;
    private readonly ICommunicationHandler _communicationHandler;

    public EmailCommunicationProcessor(IEmail email, Person person)
    {
        _email = email;
        _person = person;
        _communicationHandler = new EmailCommunicationHandler(email);
    }

    public void Execute()
    {
        $"\n({_email.RefId})".Print();

        var billHandler =  new BillHandlerFactory(_communicationHandler).Get(_person);
        billHandler.Handle();

        // "Drafted text content for Email.".Print();
        // $"Sending Email on email address '{_email.EmailAddress}'.".Print();
    }
}