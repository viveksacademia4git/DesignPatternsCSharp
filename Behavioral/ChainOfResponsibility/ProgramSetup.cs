using Bogus;
using ChainOfResponsibility.DesignPattern;
using ChainOfResponsibility.DesignPattern.Interfaces;
using ChainOfResponsibility.Enums;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility;

public static class ProgramSetup
{

    public static ICommunicationChannel SetupChainOfResponsibilityForCommunication() =>
        new LetterCommunicationChannel().AddNextInChain(new EmailCommunicationChannel())
            .AddNextInChain(new PhoneCallCommunicationChannel())
            .AddNextInChain(new SmsCommunicationChannel());

    public static IEnumerable<DataModel> GetDataModels() =>
        Enumerable.Range(0, new Faker().Random.Int(0, 10)).Select(_ => GetDataModel()).ToList();

    public static DataModel GetDataModel() =>
        new()
        {
            Name = $"{Person().FirstName} {Person().LastName}",
            Address = $"{Address().Suite}, {Address().Street}, {Address().ZipCode} {Address().City}",
            Email = new Faker().Person.Email,
            Phones = Enumerable.Range(0, new Faker().Random.Int(1, 5)).Select(_ => GetPhone()).ToList(),
            DefaultCommunicationChannelEnum = RandomCommunicationChannel()
        };

    private static IPhone GetPhone() =>
        new Phone { Number = PhoneNumber(), CallingAllowed = RandomBool(), SmsActive = RandomBool() };

    private static Person Person() => new Faker().Person;

    private static Person.CardAddress Address() => Person().Address;

    private static string PhoneNumber() => Person().Phone;

    private static bool RandomBool() => new Faker().Random.Bool();

    private static CommunicationChannelEnum RandomCommunicationChannel() =>
        new Faker().Random.Enum<CommunicationChannelEnum>();
}