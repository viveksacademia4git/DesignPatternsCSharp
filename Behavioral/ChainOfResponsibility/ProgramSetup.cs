using ChainOfResponsibility.Chains;
using ChainOfResponsibility.Chains.Interfaces;
using Models;
using Models.Components;

namespace ChainOfResponsibility;

public static class ProgramSetup
{
    public static List<IPhone> PhoneCallCommunications { get; private set; } = new();
    public static List<IPhone> SmsCommunications { get; private set; } = new();

    private static ICommunicationChannel SetupChainOfResponsibilityForCommunication()
    {
        return new LetterCommunicationChannel().AddNextInChain(new EmailCommunicationChannel())
            .AddNextInChain(new PhoneCallCommunicationChannel())
            .AddNextInChain(new SmsCommunicationChannel());
    }

    public static void StartCommunication()
    {
        PhoneCallCommunications = new List<IPhone>();
        SmsCommunications = new List<IPhone>();

        var communication = SetupChainOfResponsibilityForCommunication();

        Loader.GetRandomDataModels().ForEach(dataModel =>
        {
            Console.WriteLine($"\n({dataModel.Id})");
            communication.ProcessResponsibility(dataModel);
        });
    }
}