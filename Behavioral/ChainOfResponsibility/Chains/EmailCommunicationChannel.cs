using ChainOfResponsibility.Enums;
using DesignPatternInterfaces;
using IO;
using Models;
using Models.Components;

namespace ChainOfResponsibility.Chains;

public class EmailCommunicationChannel : CommunicationChannel
{
    public EmailCommunicationChannel() : base(CommunicationChannelEnum.Email) { }

    protected override void PerformCommunication(DataModel dataModel, ICommunicationOrganiser communicationOrganiser)
    {
        var email = GetEmail(dataModel);

        $"Scheduling Email for '{dataModel.Name}' at email '{email.EmailAddress}'.".Print();

        communicationOrganiser.Email(email);

        $"Email scheduled for '{dataModel.Name}' at email '{email.EmailAddress}'.".Print();
    }

    private static IEmail GetEmail(DataModel dataModel)
    {
        foreach (var email in dataModel.Emails)
            if (email.Default)
                return email;

        return dataModel.Emails.First();
    }
}