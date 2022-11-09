// See https://aka.ms/new-console-template for more information

using ChainOfResponsibility;
using Command.Invoker;

Task.Delay(10);

var organiser = new TelephoneCommunicationOrganiser();

Console.WriteLine("\n-------- STARTING NEW COMMUNICATION --------");
ProgramSetup.StartCommunication();
ProgramSetup.PhoneCallCommunications.ForEach(phone => organiser.PhoneCall(phone));
ProgramSetup.SmsCommunications.ForEach(phone => organiser.Sms(phone));

Console.WriteLine("\n-------- Organising Communication --------");
organiser.Organise();

Console.WriteLine("\n-------- STARTING NEW COMMUNICATION --------");
ProgramSetup.StartCommunication();
ProgramSetup.PhoneCallCommunications.ForEach(phone => organiser.PhoneCall(phone));
ProgramSetup.SmsCommunications.ForEach(phone => organiser.Sms(phone));

Console.WriteLine("\n-------- Organising Communication --------");
organiser.Organise();
