// GRAVITY ROLLER COASTER
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

using QueueItem = (System.DateTime StartedAt, System.ConsoleColor Color);

const int rideSeconds = 10;
Random random = new();
CircularQueue<QueueItem> queue = new(12);
ConsoleColor color = ConsoleColor.Black;

while (true)
{
    while (queue.Peek() != null)
    {
        QueueItem item = queue.Peek()!.Value;
        TimeSpan elapsed = DateTime.Now - item.StartedAt;
        if (elapsed.TotalSeconds < rideSeconds) { break; }
        queue.Dequeue();
        Log($"> Exits\tTotal: {queue.Count}", item.Color);
    }

    bool isNew = random.Next(3) == 1;
    if (isNew)
    {
        color = color == ConsoleColor.White
            ? ConsoleColor.DarkBlue
            : (ConsoleColor)(((int)color) + 1);
        if (queue.Enqueue((DateTime.Now, color)))
        {
            Log($"< Enters\tTotal: {queue.Count}", color);
        }
        else
        {
            Log($"! Not allowed\tTotal: {queue.Count}", ConsoleColor.DarkGray);
        }
    }

    await Task.Delay(500);
}

void Log(string text, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine($"{DateTime.Now:HH:mm:ss} {text}");
    Console.ResetColor();
}