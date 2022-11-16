// See https://aka.ms/new-console-template for more information

using ChainOfResponsibility;
using Command.Invoker;
using IO;
using Singleton;

var organiser = new CommunicationOrganiser();

".\n.\n-------- Initialize Communication --------\n".Print();
ProgramSetup.InitializeCommunication(organiser);

"\n-------- Start Communication --------".Print();
organiser.Start();


" \n \n-------- Initialize Communication --------\n".Print();
ProgramSetup.InitializeCommunication(organiser);

"\n-------- Start Communication --------".Print();
organiser.Start();


"\n-------- Start Call Center --------".Print();

CallCenter.StartCalling();