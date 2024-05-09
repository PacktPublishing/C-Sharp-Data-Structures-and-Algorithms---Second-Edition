// CALL CENTER WITH MANY CONSULTANTS
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

using System.Collections.Concurrent;

public class CallCenter
{
    private int _counter = 0;
    public ConcurrentQueue<IncomingCall> Calls { get; private set; }
    public CallCenter() => Calls = new ConcurrentQueue<IncomingCall>();

    public IncomingCall Call(int clientId)
    {
        IncomingCall call = new()
        {
            Id = ++_counter,
            ClientId = clientId,
            CallTime = DateTime.Now
        };
        Calls.Enqueue(call);
        return call;
    }

    public IncomingCall? Answer(string consultant)
    {
        if (!Calls.IsEmpty && Calls.TryDequeue(out IncomingCall? call))
        {
            call.Consultant = consultant;
            call.AnswerTime = DateTime.Now;
            return call;
        }
        return null;
    }

    public void End(IncomingCall call) => call.EndTime = DateTime.Now;

    public bool AreWaitingCalls() => !Calls.IsEmpty;
}

