using ChainOfResponsibility.Chains;
using DesignPatternInterfaces;
using Models;

namespace ChainOfResponsibility;

public static class ProgramSetup
{
    private static ICommunicationChannel ConfigureChainOfResponsibilityForCommunication()
    {
        return new LetterCommunicationChannel().AddNextInChain(new EmailCommunicationChannel())
            .AddNextInChain(new PhoneCallCommunicationChannel())
            .AddNextInChain(new SmsCommunicationChannel());
    }

    public static void InitializeCommunication(ICommunicationProcessInvoker communicationProcessInvoker)
    {
        var communication = ConfigureChainOfResponsibilityForCommunication();

        DataLoader.GetRandomDataModels().ForEach(dataModel =>
        {
            Console.WriteLine($"\n({dataModel.Id})");
            communication.Process(dataModel, communicationProcessInvoker);
        });
    }
}