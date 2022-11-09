using Bogus;
using ChainOfResponsibility.Enums;
using Models.Components;

namespace Models;

public class Loader
{
    public static List<DataModel> GetRandomDataModels()
    {
        return Enumerable.Range(0, new Faker().Random.Int(1, 10)).Select(id => GetDataModel(id + 1)).ToList();
    }

    private static DataModel GetDataModel(long id = 1)
    {
        return new()
        {
            Id = id,
            Name = $"{Person().FirstName} {Person().LastName}",
            Address = $"{Address().Suite}, {Address().Street}, {Address().ZipCode} {Address().City}",
            Email = new Faker().Person.Email,
            Phones = Enumerable.Range(0, new Faker().Random.Int(1, 5)).Select(_ => GetPhone(id)).ToList(),
            DefaultCommunicationChannelEnum = RandomCommunicationChannel()
        };
    }

    private static IPhone GetPhone(long id)
    {
        return new Phone
            { RefId = id, Number = PhoneNumber(), CallingAllowed = RandomBool(), SmsActive = RandomBool() };
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