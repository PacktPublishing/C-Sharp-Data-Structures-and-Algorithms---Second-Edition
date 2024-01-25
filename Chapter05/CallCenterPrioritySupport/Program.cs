// CALL CENTER WITH PRIORITY SUPPORT
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

Random random = new();

CallCenter center = new();
center.Call(1234, false);
center.Call(5678, true);
center.Call(1468, false);
center.Call(9641, true);

while (center.AreWaitingCalls())
{
    IncomingCall call = center.Answer("Marcin")!;
    Log($"Call #{call.Id} from client #{call.ClientId} is answered by { call.Consultant}.", call.IsPriority);
    await Task.Delay(random.Next(1000, 10000));
    center.End(call);
    Log($"Call #{call.Id} from client #{call.ClientId} is ended by { call.Consultant}.", call.IsPriority);
}

void Log(string text, bool isPriority)
{
    Console.ForegroundColor = isPriority ? ConsoleColor.Red : ConsoleColor.Gray;
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");
    Console.ResetColor();
}
