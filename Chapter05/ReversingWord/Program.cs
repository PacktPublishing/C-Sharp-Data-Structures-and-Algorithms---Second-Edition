// REVERSING A WORD
// Chapter 5 (Stacks and Queues)
// C# Data Structures and Algorithms, Second Edition

string text = "MARCIN";
Stack<char> chars = new();
foreach (char c in text) { chars.Push(c); }
while (chars.Count > 0) { Console.Write(chars.Pop()); }
