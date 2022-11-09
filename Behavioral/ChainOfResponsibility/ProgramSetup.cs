using Bogus;
using ChainOfResponsibility.CommunicationChannels;
using ChainOfResponsibility.DesignPattern.Interfaces;
using ChainOfResponsibility.Enums;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility;

public static class ProgramSetup
{
    public static ICommunicationChannel SetupChainOfResponsibilityForCommunication()
    {
        return new LetterCommunicationChannel().AddNextInChain(new EmailCommunicationChannel())
            .AddNextInChain(new PhoneCallCommunicationChannel())
            .AddNextInChain(new SmsCommunicationChannel());
    }

    public static IEnumerable<DataModel> GetDataModels()
    {
        return Enumerable.Range(0, new Faker().Random.Int(0, 10)).Select(_ => GetDataModel()).ToList();
    }

    public static DataModel GetDataModel()
    {
        return new()
        {
            Name = $"{Person().FirstName} {Person().LastName}",
            Address = $"{Address().Suite}, {Address().Street}, {Address().ZipCode} {Address().City}",
            Email = new Faker().Person.Email,
            Phones = Enumerable.Range(0, new Faker().Random.Int(1, 5)).Select(_ => GetPhone()).ToList(),
            DefaultCommunicationChannelEnum = RandomCommunicationChannel()
        };
    }

    private static IPhone GetPhone()
    {
        return new Phone { Number = PhoneNumber(), CallingAllowed = RandomBool(), SmsActive = RandomBool() };
    }

    private static Person Person()
    {
        return new Faker().Person;
    }

    private static Person.CardAddress Address()
    {
        return Person().Address;
    }

    private static string PhoneNumber()
    {
        return Person().Phone;
    }

    private static bool RandomBool()
    {
        return new Faker().Random.Bool();
    }

    private static CommunicationChannelEnum RandomCommunicationChannel()
    {
        return new Faker().Random.Enum<CommunicationChannelEnum>();
    }
}