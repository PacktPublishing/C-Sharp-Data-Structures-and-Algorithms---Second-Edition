// CALL CENTER WITH A SINGLE CONSULTANT
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

public class CallCenter
{
    private int _counter = 0;
    public Queue<IncomingCall> Calls { get; private set; }
    public CallCenter() => Calls = new Queue<IncomingCall>();

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
        if (!AreWaitingCalls()) { return null; }

        IncomingCall call = Calls.Dequeue();
        call.Consultant = consultant;
        call.AnswerTime = DateTime.Now;
        return call;
    }

    public void End(IncomingCall call) => call.EndTime = DateTime.Now;

    public bool AreWaitingCalls() => Calls.Count > 0;
}
