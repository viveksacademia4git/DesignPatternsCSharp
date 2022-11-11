using DesignPatternInterfaces;
using IO;
using Models.Components;

namespace Command.Processors;

public class LetterCommunicationExecutor : ICommunicationExecutor
{
    private readonly IAddress _address;

    public LetterCommunicationExecutor(IAddress address)
    {
        _address = address;
    }

    public void Execute()
    {
        $"\n({_address.RefId})".Print();
        "Drafting text content for Letter.".Print();
        $"Sending Letter at address '{_address.Suite}, {_address.Street}, {_address.Zip} {_address.City}'.".Print();
    }
}