using ChainOfResponsibility.Enums;
using Models.Components;

namespace Models;

public class DataModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public ICollection<IPhone> Phones { get; set; }
    public CommunicationChannelEnum DefaultCommunicationChannelEnum { get; set; }
}