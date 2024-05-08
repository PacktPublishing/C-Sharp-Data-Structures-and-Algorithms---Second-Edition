// CALL CENTER WITH A SINGLE CONSULTANT
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

Random random = new();

CallCenter center = new();
center.Call(1234);
center.Call(5678);
center.Call(1468);
center.Call(9641);

while (center.AreWaitingCalls())
{
    IncomingCall call = center.Answer("Marcin")!;
    Log($"Call #{call.Id} from client #{call.ClientId} answered by { call.Consultant}.");
    await Task.Delay(random.Next(1000, 10000));
    center.End(call);
    Log($"Call #{call.Id} from client #{call.ClientId} ended by { call.Consultant}."); 
}

void Log(string text) => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");
