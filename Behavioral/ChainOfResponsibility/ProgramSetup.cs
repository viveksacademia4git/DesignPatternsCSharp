using ChainOfResponsibility.Chains;
using DesignPatternInterfaces;
using Models;
using Models.Components;

namespace ChainOfResponsibility;

public static class ProgramSetup
{
    private static ICommunicationChannel ConfigureChainOfResponsibilityForCommunication()
    {
        return new LetterCommunicationChannel().AddNextInChain(new EmailCommunicationChannel())
            .AddNextInChain(new PhoneCallCommunicationChannel())
            .AddNextInChain(new SmsCommunicationChannel());
    }

    public static void InitializeCommunication(ICommunicationOrganiser communicationOrganiser)
    {

        var communication = ConfigureChainOfResponsibilityForCommunication();

        Loader.GetRandomDataModels().ForEach(dataModel =>
        {
            Console.WriteLine($"\n({dataModel.Id})");
            communication.Process(dataModel, communicationOrganiser);
        });
    }
}