using ChainOfResponsibility.Enums;
using DesignPatternInterfaces;
using IO;
using Models;
using Models.Components;

namespace ChainOfResponsibility.Chains;

public class EmailCommunicationChannel : CommunicationChannel
{
    public EmailCommunicationChannel() : base(CommunicationChannelEnum.Email) { }

    protected override void PerformCommunication(Person person, ICommunicationOrganiser communicationOrganiser)
    {
        var email = GetEmail(person);

        $"Scheduling Email for '{person.Name}' at email '{email.EmailAddress}'.".Print();

        communicationOrganiser.Email(email);

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