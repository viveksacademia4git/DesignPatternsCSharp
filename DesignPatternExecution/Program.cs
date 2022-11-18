// See https://aka.ms/new-console-template for more information

using ChainOfResponsibility;
using Command.Invokers;
using IO;
using Singleton;

var organiser = new CommunicationProcessInvoker();

".\n.\n-------- Initialize Communication --------\n".Print();
ProgramSetup.InitializeCommunication(organiser);

"\n-------- Start Communication --------".Print();
organiser.Invoke();


" \n \n-------- Initialize Communication --------\n".Print();
ProgramSetup.InitializeCommunication(organiser);

"\n-------- Start Communication --------".Print();
organiser.Invoke();


"\n-------- Start Call Center --------".Print();

CallCenterHandler.StartCalling();