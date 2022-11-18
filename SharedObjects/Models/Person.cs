using Enums;
using SharedObjects.Models.Components;

namespace SharedObjects.Models;

public class Person
{
    public long Id { get; set; }

    public string Name { get; set; }

    public IAddress Address { get; set; }

    public ICollection<IEmail> Emails { get; set; }

    public ICollection<IPhone> Phones { get; set; }

    public CommunicationChannelEnum DefaultCommunicationChannelEnum { get; set; }

    public BillStatus BillStatus { get; set; }
}