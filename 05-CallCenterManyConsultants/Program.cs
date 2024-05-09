// CALL CENTER WITH MANY CONSULTANTS
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

Random random = new();
CallCenter center = new();
Parallel.Invoke(
    () => Clients(center),
    () => Consultant(center, "Marcin", ConsoleColor.Red),
    () => Consultant(center, "James", ConsoleColor.Yellow),
    () => Consultant(center, "Olivia", ConsoleColor.Green));

void Clients(CallCenter center)
{
    while (true)
    {
        int clientId = random.Next(1, 10000);
        IncomingCall call = center.Call(clientId);
        Log($"Incoming call #{call.Id} from client #{clientId}");
        Log($"Waiting calls in the queue: {center.Calls.Count}");
        Thread.Sleep(random.Next(500, 2000));
    }
}

void Consultant(CallCenter center, string name, ConsoleColor color)
{
    while (true)
    {
        Thread.Sleep(random.Next(500, 1000));
        IncomingCall? call = center.Answer(name);
        if (call == null) { continue; }

        Log($"Call #{call.Id} from client #{call.ClientId} answered by {call.Consultant}.", color);
        Thread.Sleep(random.Next(1000, 10000));
        center.End(call);
        Log($"Call #{call.Id} from client #{call.ClientId} ended by {call.Consultant}.", color);
    }
}

void Log(string text, ConsoleColor color = ConsoleColor.Gray)
{
    Console.ForegroundColor = color;
    Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {text}");
    Console.ResetColor();
}
