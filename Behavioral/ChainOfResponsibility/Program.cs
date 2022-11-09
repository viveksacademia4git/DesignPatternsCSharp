// See https://aka.ms/new-console-template for more information

using static ChainOfResponsibility.ProgramSetup;

Console.WriteLine(".");
Console.WriteLine("-------- Communication Process Started --------");
Console.WriteLine(".");

var communication = SetupChainOfResponsibilityForCommunication();

var count = 0;

// Single Data
Console.WriteLine($"\n({++count})");
communication.ProcessResponsibility(GetDataModel());

// Multiple Data
foreach (var dataModel in GetDataModels())
{
    Console.WriteLine($"\n({++count})");
    // Console.WriteLine($"\n-----------------({++count})-----------------");
    communication.ProcessResponsibility(dataModel);
}