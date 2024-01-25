// CALL CENTER WITH PRIORITY SUPPORT
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

using Priority_Queue;

public class CallCenter
{
    private int _counter = 0;
    public SimplePriorityQueue<IncomingCall> Calls { get; private set; }
    public CallCenter() => Calls = new SimplePriorityQueue<IncomingCall>();

    public IncomingCall Call(int clientId, bool isPriority)
    {
        IncomingCall call = new()
        {
            Id = ++_counter,
            ClientId = clientId,
            CallTime = DateTime.Now,
            IsPriority = isPriority
        };
        Calls.Enqueue(call, isPriority ? 0 : 1);
        return call;
    }


    public IncomingCall? Answer(string consultant)
    {
        if (!AreWaitingCalls()) { return null; }

        IncomingCall call = Calls.Dequeue();
        call.Consultant = consultant;
        call.AnswerTime = DateTime.Now;
        return call;
    }

    public void End(IncomingCall call) => call.EndTime = DateTime.Now;

    public bool AreWaitingCalls() => Calls.Count > 0;
}
