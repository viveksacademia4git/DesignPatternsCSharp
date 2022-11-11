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
            Address = GetAddress(id),
            Emails = Enumerable.Range(0, new Faker().Random.Int(1, 2)).Select(_ => GetEmail(id)).ToList(),
            Phones = Enumerable.Range(0, new Faker().Random.Int(1, 3)).Select(_ => GetPhone(id)).ToList(),
            DefaultCommunicationChannelEnum = RandomCommunicationChannel()
        };
    }

    private static IAddress GetAddress(long id)
    {
        return new Address
        {
            RefId = id, Suite = Address().Suite, Street = Address().Street, City = Address().City,
            Zip = Address().ZipCode
        };
    }

    private static IEmail GetEmail(long id)
    {
        return new Email
            { RefId = id, EmailAddress = Person().Email, Default = RandomBool()};
    }

    private static IPhone GetPhone(long id)
    {
        return new Phone
            { RefId = id, Number = PhoneNumber(), CallingAllowed = true, SmsActive = true };
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