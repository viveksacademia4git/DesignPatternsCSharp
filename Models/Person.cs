using ChainOfResponsibility.Enums;
using Models.Components;

namespace Models;

public class Person
{
    public long Id { get; set; }

    public string Name { get; set; }

    public IAddress Address { get; set; }

    public ICollection<IEmail> Emails { get; set; }

    public ICollection<IPhone> Phones { get; set; }

    public CommunicationChannelEnum DefaultCommunicationChannelEnum { get; set; }
}