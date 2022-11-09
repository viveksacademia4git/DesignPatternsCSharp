using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.Model;

public class DataModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public ICollection<IPhone> Phones { get; set; }
    public CommunicationChannelEnum DefaultCommunicationChannelEnum { get; set; }
}