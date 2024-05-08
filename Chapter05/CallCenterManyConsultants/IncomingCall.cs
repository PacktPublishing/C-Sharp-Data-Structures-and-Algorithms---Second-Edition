// CALL CENTER WITH MANY CONSULTANTS
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

public class IncomingCall
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime CallTime { get; set; }
    public DateTime? AnswerTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Consultant { get; set; }
}
