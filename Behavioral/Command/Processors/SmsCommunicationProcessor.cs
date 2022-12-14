using Bridge.Abstraction2;
using Factory;
using SharedObjects.Interfaces;
using SharedObjects.IO;
using SharedObjects.Models;
using SharedObjects.Models.Components;

namespace Command.Processors;

public class SmsCommunicationProcessor : ICommunicationProcessor
{
    private readonly SmsCommunicationHandler _communicationHandler;
    private readonly Person _person;
    private readonly IPhone _phone;

    public SmsCommunicationProcessor(IPhone phone, Person person)
    {
        _phone = phone;
        _person = person;
        _communicationHandler = new SmsCommunicationHandler(phone);
    }

    public void Execute()
    {
        $"\n({_phone.RefId})".Print();

        var billHandler = new BillHandlerFactory(_communicationHandler).Get(_person);
        billHandler.Handle();

        // "Drafted text content for SMS.".Print();
        // $"Sending SMS on phone number '{_phone.Number}'.".Print();
    }
}