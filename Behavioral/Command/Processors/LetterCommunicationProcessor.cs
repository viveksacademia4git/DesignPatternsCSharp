﻿
using Bridge.Abstraction2;
using DesignPatternInterfaces;
using Factory;
using IO;
using Models;
using Models.Components;

namespace Command.Processors;

public class LetterCommunicationProcessor : ICommunicationProcessor
{
    private readonly IAddress _address;
    private readonly Person _person;
    private readonly ICommunicationHandler _communicationHandler;

    public LetterCommunicationProcessor(IAddress address, Person person)
    {
        _address = address;
        _person = person;
        _communicationHandler = new LetterCommunicationHandler(address);
    }

    public void Execute()
    {
        $"\n({_address.RefId})".Print();

        var billHandler =  new BillHandlerFactory(_communicationHandler).Get(_person);
        billHandler.Handle();

        // "Drafting text content for Letter.".Print();
        // $"Sending Letter at address '{_address.Suite}, {_address.Street}, {_address.Zip} {_address.City}'.".Print();
    }
}