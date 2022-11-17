using Bridge.Abstraction2;
using IO;
using Models;

namespace Bridge.Abstraction1;

public abstract class BillHandler
{
    protected readonly ICommunicationHandler CommunicationHandler;
    protected readonly Person Person;

    protected BillHandler(ICommunicationHandler communicationHandler, Person person)
    {
        CommunicationHandler = communicationHandler;
        Person = person;
    }

    public abstract void Handle();
}

public class PaidBillHandler : BillHandler
{
    public PaidBillHandler(ICommunicationHandler communicationHandler, Person person) : base(communicationHandler, person) { }

    public override void Handle()
    {
        $"Drafting promotional text content for '{Person.Name}'.".Print();
        CommunicationHandler.Send();
    }
}

public class DueBillHandler : BillHandler
{
    public DueBillHandler(ICommunicationHandler communicationHandler, Person person) : base(communicationHandler, person) { }

    public override void Handle()
    {
        $"Drafting reminder text content for '{Person.Name}'.".Print();
        CommunicationHandler.Send();
    }
}

public class LateBillHandler : BillHandler
{
    public LateBillHandler(ICommunicationHandler communicationHandler, Person person) : base(communicationHandler, person) { }

    public override void Handle()
    {
        $"Drafting urgent payment content for '{Person.Name}'.".Print();
        CommunicationHandler.Send();
    }
}
