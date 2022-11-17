using Bridge.Abstraction2;
using DesignPatternInterfaces;
using Factory;
using IO;
using Models;
using Models.Components;

namespace Command.Processors;

public class SmsCommunicationProcessor : ICommunicationProcessor
{
    private readonly IPhone _phone;
    private readonly Person _person;
    private readonly SmsCommunicationHandler _communicationHandler;

    public SmsCommunicationProcessor(IPhone phone, Person person)
    {
        _phone = phone;
        _person = person;
        _communicationHandler = new SmsCommunicationHandler(phone);
    }

    public void Execute()
    {
        $"\n({_phone.RefId})".Print();

        var billHandler =  new BillHandlerFactory(_communicationHandler).Get(_person);
        billHandler.Handle();

        // "Drafted text content for SMS.".Print();
        // $"Sending SMS on phone number '{_phone.Number}'.".Print();
    }
}