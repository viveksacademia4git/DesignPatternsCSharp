using Command.Processors;
using Enums;
using SharedObjects.Interfaces;
using SharedObjects.IO;
using SharedObjects.Models;
using SharedObjects.Models.Components;

namespace ChainOfResponsibility.Chains;

public class EmailCommunicationChannel : CommunicationChannel
{
    public EmailCommunicationChannel() : base(CommunicationChannelEnum.Email) { }

    protected override void PerformCommunication(Person person,
        ICommunicationProcessInvoker communicationProcessInvoker)
    {
        var email = GetEmail(person);

        $"Scheduling Email for '{person.Name}' at email '{email.EmailAddress}'.".Print();

        communicationProcessInvoker.Register(new EmailCommunicationProcessor(email, person));

        $"Email scheduled for '{person.Name}' at email '{email.EmailAddress}'.".Print();
    }

    private static IEmail GetEmail(Person person)
    {
        foreach (var email in person.Emails)
            if (email.Default)
                return email;

        return person.Emails.First();
    }
}