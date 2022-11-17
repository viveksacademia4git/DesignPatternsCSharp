using Bridge.Abstraction1;
using Bridge.Abstraction2;
using Enums;
using Models;

namespace Factory;

public class BillHandlerFactory
{
    private readonly ICommunicationHandler _communicationHandler;

    public BillHandlerFactory(ICommunicationHandler communicationHandler)
    {
        _communicationHandler = communicationHandler;
    }

    public BillHandler Get(Person person)
    {
        return person.BillStatus switch
        {
            BillStatus.Due => new DueBillHandler(_communicationHandler, person),
            BillStatus.Paid => new PaidBillHandler(_communicationHandler, person),
            BillStatus.Late => new LateBillHandler(_communicationHandler, person),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}